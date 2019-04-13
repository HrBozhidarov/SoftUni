const petService = (() => {
    function getAllPets() {
        return kinvey.get('appdata', 'pets', 'kinevy');
    }

    function postPet(data) {
        return kinvey.post('appdata', 'pets', 'kinevy', data);
    }

    function removePet(id) {
        return kinvey.remove('appdata', `pets/${id}`, 'kinevy');
    }

    return {
        getAllPets,
        postPet,
        removePet
    }
})()