function printInvoke() {
    window.print();
}

function downloadFile(data, fileName, mimeType) {
    var a = document.createElement("a");
    var file = new Blob([data], { type: mimeType });
    a.href = URL.createObjectURL(file);
    a.download = fileName;
    a.click();
}