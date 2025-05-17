let teamGeneratorOBJ = {
    members : [],
    numberOfTeams: 1
}

let playerInputs = document.querySelectorAll("#add-player-container input")
let addPlayerButton = document.querySelector("#add-player-container button")

let displayer = document.getElementById("players-displayer")

function displayPlayers(){
    displayer.innerHTML = ""

    for (let i = 0; i < teamGeneratorOBJ.members.length; i++) {
        let p = document.createElement("p")
        p.innerHTML = teamGeneratorOBJ.members[i].name + " " + teamGeneratorOBJ.members[i].age 
        displayer.appendChild(p)
    }
}

function addPlayer(){
    teamGeneratorOBJ.members.push({name: playerInputs[0].value, age: playerInputs[1].value})
    for (let i = 0; i < playerInputs.length; i++) {
        playerInputs[i].value = ""
    }

    addPlayerButton.disabled = true
    document.querySelector("#number-of-teams-container button").disabled = false

    displayPlayers()
}

function generateCards(){
    fetch('http://localhost:5090/csapat', {
        method: 'POST',
        headers: { 'Content-Type' : 'application/json', },
        body: JSON.stringify(teamGeneratorOBJ)
    })
    .then(resp => resp.json())
    .then(data => {
        let cardDisplayer = document.getElementById("cards-container")
        for (let i = 0; i < data.length; i++) {
            cardDisplayer.appendChild(createCard("Team " + (i+1), data[i]))
        }
    });
    console.log(JSON.stringify(teamGeneratorOBJ))
}

function createTeams(){
    document.getElementById("cards-container").innerHTML = ""
    let teamNumber = document.querySelector("#number-of-teams-container input").value
    teamGeneratorOBJ.numberOfTeams = teamNumber

    if(teamNumber > teamGeneratorOBJ.members.length){
        alert("A csapatok száma nem haladhatja meg a játékosok számát!")
    }
    else{
        generateCards()
    }
}

function validateForm(){

    let valid = true
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

function random_bg_color() {
    var x = Math.floor(Math.random() * 256);
    var y = Math.floor(Math.random() * 256);
    var z = Math.floor(Math.random() * 256);
    var bgColor = "rgb(" + x + "," + y + "," + z + ")";
    
    return bgColor
}

function createCard(teamName, teamMembers){
    let cardDiv = document.createElement("div")
    let cardHeader = document.createElement("div")
    let cardBody = document.createElement("div")

    cardDiv.classList.add("card")
    cardDiv.style.flexBasis = "18rem"
    cardDiv.style.backgroundColor = random_bg_color()


    cardHeader.classList.add("card-header")
    cardHeader.innerHTML = teamName

    cardBody.classList.add("card-body")
    for (let i = 0; i < teamMembers.length; i++) {
        let p = document.createElement("p")
        p.innerHTML = teamMembers[i].name + " " + teamMembers[i].age
        cardBody.appendChild(p)
    }

    cardDiv.appendChild(cardHeader)
    cardDiv.appendChild(cardBody)

    return cardDiv
}