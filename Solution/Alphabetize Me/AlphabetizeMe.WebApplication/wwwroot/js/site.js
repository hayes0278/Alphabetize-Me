
function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(name) {
    const cookieName = name + "=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const cookieArray = decodedCookie.split(';');

    for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i];
        while (cookie.charAt(0) === ' ') {
            cookie = cookie.substring(1);
        }
        if (cookie.indexOf(cookieName) === 0) {
            return cookie.substring(cookieName.length, cookie.length);
        }
    }
    return null; // Return null if the cookie is not found
}

function redirectToNewPage(newUrl) {
    window.location.href = newUrl;
}

function replaceCurrentPage(newUrl) {
    window.location.replace(newUrl);
}

function changeLanguage(newLanguage) {
    setCookie("culture", newLanguage, 5);
    replaceCurrentPage('/')
}
function startAgain() {
    replaceCurrentPage("/");
    document.getElementById("txtInput").focus();
}

async function pasteTextFromClipboard() {
    try {
        const text = await navigator.clipboard.readText();
        console.log("Pasted text:", text); ///
        document.getElementById('myOutputElement').innerText = text;
    } catch (err) {
        console.error("Failed to read clipboard contents:", err);
    }
}

async function copyTextToClipboard() {
    try {
        document.getElementById("txtInput").nodeValue;
        await navigator.clipboard.writeText(textToCopy);
        console.log('Text copied to clipboard:', textToCopy); /// 
    } catch (err) {
        console.error('Failed to copy text:', err);
    }
}

document.getElementById("year").innerHTML = new Date().getFullYear();