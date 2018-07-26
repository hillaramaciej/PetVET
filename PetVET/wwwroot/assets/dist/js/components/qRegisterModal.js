function viewModelConstructor(params) {
    // 'params' is an object whose key/value pairs are the parameters
    // passed from the component binding or custom element.
    this.someProperty = params.something;
}

function templateConstructor(name) {
    var template = '<h2>' + name + '</h2>\r\n';
    return template;
}


ko.components.register('data-display', {
    viewModel: {
        createViewModel: function(params, componentInfo) {
            var componentVM = new viewModelConstructor(params);
            var template = templateConstructor(componentVM.name);
            ko.virtualElements.setDomNodeChildren(componentInfo.element, ko.utils.parseHtmlFragment(template));
            return componentVM;
        }
    },
    template: []
});


