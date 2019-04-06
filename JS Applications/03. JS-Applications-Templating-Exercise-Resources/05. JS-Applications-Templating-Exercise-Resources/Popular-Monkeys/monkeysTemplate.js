$(() => {
    let monkeyRoot = $('.monkeys').eq(0);
    let template = Handlebars.compile($('#monkey-template').html());
    let templateMonkey = template({monkeys});

    monkeyRoot.html(templateMonkey);
    monkeyRoot.on('click','button',loadInfo);

    function loadInfo(e) {
        let target = $(e.target).next();
            let isVisit = target.css('display');

            if(isVisit === 'none') {
                target.css('display','block');
            }
            else {
                target.css('display','none');
            }
    }
})