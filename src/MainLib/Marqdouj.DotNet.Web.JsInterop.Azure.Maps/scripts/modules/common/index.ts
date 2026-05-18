import * as atlas from "azure-maps-control"

export enum EditAction {
    Update = 'update',
    Replace = 'replace',
}

export interface JSInterop {
    id: string;
}

export enum LogLevel {
    Trace = 0,
    Debug = 1,
    Information = 2,
    Warn = 3,
    Error = 4,
    Critical = 5,
    None = 6
}

export type Properties = { [key: string]: any };

export class Logger {
    static currentLevel: LogLevel = LogLevel.Information;

    static #GetMapHeader(mapId: string): string {
        return `Map with Id '${mapId}'`;
    }

    static logMapMessage(mapId: string, level: LogLevel, message: string, ...optionalParams: any[]): void {
        if (level < this.currentLevel)
            return;

        const logOutput = `${this.#GetMapHeader(mapId)} [${Logger.#logLevelName(level)}] ${message}`;
        this.#logToConsole(logOutput, level, ...optionalParams);
    }

    static logMessage(header: string, level: LogLevel, message: string, ...optionalParams: any[]): void {
        if (level < this.currentLevel)
            return;

        const logOutput = `${header} [${Logger.#logLevelName(level)}] ${message}`;
        this.#logToConsole(logOutput, level, ...optionalParams);
    }

    static #logToConsole(logOutput: string, level: LogLevel, ...optionalParams: any[]) {
        switch (level) {
            case LogLevel.Trace:
                console.trace(logOutput, ...optionalParams);
                break;
            case LogLevel.Debug:
                console.debug(logOutput, ...optionalParams);
                break;
            case LogLevel.Information:
                console.info(logOutput, ...optionalParams);
                break;
            case LogLevel.Warn:
                console.warn(logOutput, ...optionalParams);
                break;
            case LogLevel.Error:
                console.error(logOutput, ...optionalParams);
                break;
            case LogLevel.Critical:
                console.error(`CRITICAL: ${logOutput}`, ...optionalParams);
                break;
        }
    }

    static #logLevelName(level: LogLevel): string {
        return LogLevel[level];
    }
}

export class Helpers {
    /**
    * Recursively replaces all `null` values in an object with `undefined`.
    * Works for nested objects and arrays.
    */
    static nullToUndefined<T>(obj: T): T {
        if (obj === null) {
            // Replace null with undefined
            return undefined as unknown as T;
        }

        if (Array.isArray(obj)) {
            // Map through arrays
            return obj.map(item => this.nullToUndefined(item)) as unknown as T;
        }

        if (typeof obj === "object" && obj !== null) {
            // Map through object properties
            const result: any = {};
            for (const [key, value] of Object.entries(obj)) {
                result[key] = this.nullToUndefined(value);
            }
            return result;
        }

        // Return primitive values as-is
        return obj;
    }

    /**
    * Recursively removes properties with null or undefined values from an object.
    * Works with nested objects and arrays.
    */
    static removeNullish<T>(obj: T): T {
        if (obj === null || obj === undefined) {
            // If the value itself is nullish, return as-is (caller may skip it)
            return obj;
        }

        if (Array.isArray(obj)) {
            // Recursively clean each element in the array
            return obj
                .map(item => this.removeNullish(item))
                .filter(item => item !== null && item !== undefined) as unknown as T;
        }

        if (typeof obj === "object") {
            const cleaned: any = {};
            for (const [key, value] of Object.entries(obj)) {
                if (value !== null && value !== undefined) {
                    const cleanedValue = this.removeNullish(value);
                    // Only keep if not nullish after cleaning
                    if (cleanedValue !== null && cleanedValue !== undefined) {
                        cleaned[key] = cleanedValue;
                    }
                }
            }
            return cleaned;
        }

        // Primitive value (string, number, boolean, etc.)
        return obj;

        // Example usage:
        //const data = {
        //    name: "Alice",
        //    age: null,
        //    address: {
        //        street: undefined,
        //        city: "Wonderland",
        //        coords: {
        //            lat: null,
        //            lng: 123
        //        }
        //    },
        //    hobbies: [null, "reading", undefined, "coding"]
        //};

        //const cleaned = removeNullish(data);

        //console.log(cleaned);
        /*
        {
          name: "Alice",
          address: {
            city: "Wonderland",
            coords: { lng: 123 }
          },
          hobbies: ["reading", "coding"]
        }
        */
    }

    static isEmptyOrNull(str: string | null | undefined): boolean {
        return str === null || str === undefined || str.trim() === "";
    }

    static isNotEmptyOrNull(str: string | null | undefined): boolean {
        return !this.isEmptyOrNull(str);
    }

    static isValueInEnum<T extends Record<string, string>>(enumObj: T, value: string): boolean {
        return Object.values(enumObj).includes(value as T[keyof T]);
    }

    // static isJsInterop(obj: any): boolean {
    //     return obj && obj.jsInterop != undefined;
    // }

    // static getJsInterop(obj: any): JSInterop | undefined {
    //     return this.isJsInterop(obj) ? obj.jsInterop as JSInterop : undefined;
    // }

    static isFeature(obj: any): obj is atlas.data.Feature<atlas.data.Geometry, any> {
        return obj && obj.type === 'Feature';
    }

    static isShape(obj: any): obj is atlas.Shape {
        return obj && obj.getType != undefined;
    }

    static getFeatureResult(feature: atlas.data.Feature<atlas.data.Geometry, any>): object {

        const item: object = {
            // jsInterop: this.getJsInterop(feature),
            id: feature.id?.toString(),
            type: feature.geometry.type,
            bbox: feature.bbox,
            source: "feature",
            properties: feature.properties
        };
        return item;
    }

    static getShapeResult(shape: atlas.Shape): object {
        const item: object = {
            // jsInterop: this.getJsInterop(shape),
            id: shape.getId()?.toString(),
            type: shape.getType(),
            bbox: shape.getBounds(),
            source: "shape",
            properties: shape.getProperties()
        };
        return item;
    }

    static buildShapeResults(shapes: Array<atlas.data.Feature<atlas.data.Geometry, any> | atlas.Shape>): object[] {
        const results: object[] = [];

        shapes.filter(feature => this.isFeature(feature)).forEach(feature => {
            results.push(this.getFeatureResult(feature));
        });
        shapes.filter(shape => this.isShape(shape)).forEach(shape => {
            results.push(this.getShapeResult(shape));
        });

        return results;
    }

    /**
    * Case-insensitive switch helper
    * @param value - The string to match
    * @param cases - An object where keys are case-insensitive match values
    * @param defaultCase - Optional default handler
    */
    static switchCaseInsensitive<T>(
        value: string,
        cases: Record<string, () => T>,
        defaultCase?: () => T
    ): T {
        const lowerValue = value.toLowerCase();
        for (const key of Object.keys(cases)) {
            if (key.toLowerCase() === lowerValue) {
                return cases[key]();
            }
        }
        if (defaultCase) return defaultCase();
        throw new Error(`No matching case for "${value}"`);
    }

    //    // Example usage
    //    const result = switchCaseInsensitive("HeLLo", {
    //        hello: () => "Matched hello",
    //        world: () => "Matched world",
    //    }, () => "Default case");

    //console.log(result); // "Matched hello"
}