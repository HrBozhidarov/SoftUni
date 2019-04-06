function attachEvents() {
    let townsInput = $('#towns');
    let root = $('#root');
    let btn = $('#btnLoadTowns');
    btn.on('click', load);

    function load(e) {
        let towns = townsInput.val().split(', ');
        let template = $('#towns-template').html();
        let compileTemplate = Handlebars.compile(template);
        let templateTowns = compileTemplate({towns});
        root.html(templateTowns);
    }
}