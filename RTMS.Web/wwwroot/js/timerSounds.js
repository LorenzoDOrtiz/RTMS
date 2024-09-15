function playBeep(beepType) {
    let audio;
    if (beepType === "short") {
        audio = new Audio('/sounds/short-beep.mp3');
    } else if (beepType === "long") {
        audio = new Audio('/sounds/long-beep.wav');
    }
    audio.play();
}
