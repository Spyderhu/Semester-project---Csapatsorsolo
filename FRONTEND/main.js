async function download() {
    const response = await fetch('http://localhost:5090/csapat');
    const members = await response.json();
    console.log(members);
}

download();