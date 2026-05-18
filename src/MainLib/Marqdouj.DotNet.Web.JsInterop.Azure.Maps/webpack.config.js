const path = require('path');

module.exports = {
    mode: 'production',
    entry: {
        azureMaps: "./tsgen/AzureMaps.js",
    },
    output: {
        filename: "[name].js",
        path: path.resolve(__dirname, 'wwwroot'),
        library: {
            type: "module",
        },
    },
    experiments: {
        outputModule: true,
    },
    externalsType: 'var',
    externals: {
        "azure-maps-control": "atlas",
        "azure-maps-animations": "atlas"
    },
};