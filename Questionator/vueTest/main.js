new Vue({
    el: '#app',
    data: {
        title: "Hello world!",
        styleCss: ""
    },
    methods: {
        changeText () {
            this.title = 'some new text'
        }
    }
});