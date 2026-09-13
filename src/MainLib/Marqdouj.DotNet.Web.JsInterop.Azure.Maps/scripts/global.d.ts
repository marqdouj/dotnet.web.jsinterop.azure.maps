export { };

// This tells TypeScript that DotNet is a global object provided at runtime
declare global {
    interface DotNetObject {
        invokeMethod<T = any>(assemblyName: string, methodIdentifier: string, ...args: any[]): T;
        invokeMethodAsync<T = any>(assemblyName: string, methodIdentifier: string, ...args: any[]): Promise<T>;
    }

    const DotNet: {
        invokeMethod<T = any>(assemblyName: string, methodIdentifier: string, ...args: any[]): T;
        invokeMethodAsync<T = any>(assemblyName: string, methodIdentifier: string, ...args: any[]): Promise<T>;
        createJSObjectReference(obj: any): any;
        disposeJSObjectReference(jsObjectReference: any): void;
    };
}