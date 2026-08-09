import * as atlas from "azure-maps-control"
import { Logger, LogLevel } from "./common/"

export class Atlas {
    public static setLanguage(language: string) {
        atlas.setLanguage(language);
        Logger.logMessage("Setting Language", LogLevel.Debug, `Language set to [${language}].`);
    }

    public static setView(view: string) {
        atlas.setView(view);
        Logger.logMessage("Setting View", LogLevel.Debug, `View set to [${view}].`);
    }
}