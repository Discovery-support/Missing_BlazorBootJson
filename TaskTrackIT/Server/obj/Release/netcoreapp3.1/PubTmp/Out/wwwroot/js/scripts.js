var BrowserTab = BrowserTab || {};
BrowserTab.setDocumentTitle = function (title) {
    document.title = title;
};

function scrollIdInToView(id)
{
    var elmnt = document.getElementById(id);
    if (!elmnt) {
        alert("ScrollIntoView: missing id='" + id + "'");
    }
    elmnt.scrollIntoView();
};

// Speech Recognition Entries

function startDictation() {
    if (window.hasOwnProperty('webkitSpeechRecognition')) {
        return new Promise((resolve, reject) => {
            var recognition = new webkitSpeechRecognition();
            recognition.continuous = false;
            recognition.interimResults = false;
            recognition.lang = "en-US"; // en-GB 
            recognition.start();
            recognition.onresult = function (e) {
                var text = e.results[0][0].transcript;
                recognition.stop();
                resolve(text);
            };
            recognition.onerror = function (e) {
                recognition.stop();
                resolve("");
            }
        });
    }
}

onBrowserResize = () => {
    window.addEventListener('resize', onResize);
};
getWindowSize = () => {
    return { height: window.innerHeight, width: window.innerWidth };
};
