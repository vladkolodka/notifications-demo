const defaultConfig = {
    apiUrl: 'http://localhost:5000'
};

const overrideConfig = {
    apiUrl: process.env.REACT_APP_APIURL
};

const computedConfig = Object.keys(defaultConfig)
    .reduce((obj, key) => {
        obj[key] = overrideConfig[key] || defaultConfig[key];
        return obj;
    }, {});

export default computedConfig;