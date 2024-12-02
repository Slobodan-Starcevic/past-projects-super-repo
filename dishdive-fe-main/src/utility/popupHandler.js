export function createPopup(type, message){
    const popupWrapper = document.createElement('div');
    popupWrapper.className = 'popup-wrapper';

    const popup = document.createElement('div');
    popup.className = `popup-message ${type ? type : 'default'}`;
    popup.textContent = message;

    const icon = document.createElement('i');

    switch (type.toLowerCase()) {
        case 'error':
            icon.className = 'fa-solid fa-circle-exclamation fa-xl icon';
            break;
        case 'succes':
            icon.className = 'fa-solid fa-circle-check fa-xl icon';
            break;
        default:
            icon.className = 'fa-solid fa-question fa-xl icon';
            break;
    }

    popup.insertBefore(icon, popup.firstChild);
    popupWrapper.appendChild(popup);
    document.body.appendChild(popupWrapper);

    void popupWrapper.offsetWidth;

    popupWrapper.classList.add('active');

    setTimeout(() => {
        document.body.removeChild(popupWrapper);
    }, 5000);
}