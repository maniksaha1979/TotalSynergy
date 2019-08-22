function DataApiPath() {
    var s = 'http://localhost:54967/';
    return s;
};
function trackerApiPath() {
    return 'http://localhost:65143/';
};
String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};
