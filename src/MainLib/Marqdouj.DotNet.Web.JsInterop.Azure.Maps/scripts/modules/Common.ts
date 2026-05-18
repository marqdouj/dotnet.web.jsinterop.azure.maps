
export class Common {
    static async copyTextToClipboard(text: string): Promise<copyTextResult> {
        const result: copyTextResult = { success: false, message: "" };

        try {
            // Check if Clipboard API is supported
            if (!navigator.clipboard) {
                throw new Error("Clipboard API not supported in this browser.");
            }

            await navigator.clipboard.writeText(text);

            result.message = "Text copied to clipboard.";
            result.success = true;
        } catch (err) {
            result.message = "Failed to copy text to clipboard. See browser console for error.";
            console.error("Failed to copy text: ", err);
        }

        return result;
    }
}

interface copyTextResult {
    success: boolean;
    message: string;
}
