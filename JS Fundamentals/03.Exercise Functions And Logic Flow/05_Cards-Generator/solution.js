function solve() {
    let cards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let from = document.getElementById('from');
    let to = document.getElementById('to');
    let option = document.querySelector('#exercise select');
    let allCards = document.getElementById('cards');

    document.querySelector('button').addEventListener('click', function (ev) {
        let optionValue = option.value.split(' ')[0];
        let startIndex = cards.indexOf(from.value);
        let endIndex = cards.indexOf(to.value);

        if (startIndex !== -1 && endIndex !== -1) {
            for (let i = startIndex; i <= endIndex; i++) {
                let cartName = cards[i];
                let card = createCart(optionValue, cartName);

                allCards.appendChild(card);
            }
        }

        from.value = '';
        to.value = '';
    });
    
    function createCart(suit, cardName) {
        let suitUnicode;
        switch (suit) {
            case 'Hearts': suitUnicode ='&hearts;'; break;
            case 'Spades': suitUnicode ='&spades;'; break;
            case 'Diamonds': suitUnicode ='&diamond;'; break;
            case 'Clubs': suitUnicode ='&clubs;'; break;
        }

        let cart = document.createElement('div');
        cart.setAttribute('class','card');
        cart.innerHTML = `<p>${suitUnicode}</p> <p>${cardName}</p> <p>${suitUnicode}</p>`;

        return cart;
    }
}