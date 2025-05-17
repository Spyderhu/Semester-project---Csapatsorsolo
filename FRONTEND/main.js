let playerInput = document.querySelectorAll("#addplayercontainer input")
let addPlayerButton = document.querySelector("#addplayercontainer button")

let displayer = document.getElementById("playersdisplayer")

let teamGeneratorObject = {
    players : [],
    teams : 1
}

function validateForm(){

    let valid = true

    //Ellenőrzi, hogy az inputok nem üresek-e
    for (let i = 0; i < playerInputs.length; i++) {
        if(playerInputs[i].value.trim() == "" || document.querySelector("#add-player-container input[type='number']").value < 1){
            valid = false
        }
    }
    
    if(valid){
        addPlayerButton.disabled = false
    }
    else{
        addPlayerButton.disabled = true
    }
}