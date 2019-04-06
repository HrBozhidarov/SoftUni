$(() => {
    renderCatTemplate();

    function renderCatTemplate() {
        let allCats= $('#allCats');

        allCats.on('click','button',getStatus);

        function getStatus(e) {
            let target = $(e.target).next();
            let isVisit = target.css('display');

            if(isVisit === 'none') {
                target.css('display','block');
            }
            else {
                target.css('display','none');
            }
        }

        let template = Handlebars.compile($('#cat-template').html());
        let templateCats = template({cats: this.cats});

        allCats.html(templateCats);
    }

})