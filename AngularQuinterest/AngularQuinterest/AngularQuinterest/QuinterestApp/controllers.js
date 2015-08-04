(function () {
    
    var boards = [
        {
            id: 1,
            boardName: "Vacations",
            imageUrl: "http://wdy.h-cdn.co/assets/cm/15/09/54f0fbd48fba0_-_1-couple-vacation-tropical-lgn.jpg",
            description: "Places I want to go",
            numPins: 2
        },
        {
            id: 2,
            boardName: "Animals",
            imageUrl: "http://www.stylemotivation.com/wp-content/uploads/2013/07/cute-baby-animals-3.jpg",
            description: "Adorable cuddly babies!",
            numPins: 1
        }
    ];


    var pins = [
        {
            id: 1,
            title: "French Polynesia",
            imageUrl: "http://www.charterworld.com/news/wp-content/uploads/2011/06/Bora-Bora-in-French-Polynesia-665x346.jpg",
            website: "http://www.frenchpolynesia.com",
            boardId: 1,
            shortDescription: "Want to go back",
            longDescription: "Lorem ipsum dolor sit amet, cursus elit ut turpis, vestibulum et accumsan aliquet fermentum erat et, dapibus fringilla, mauris imperdiet fusce odit ut at sollicitudin, vestibulum mauris accumsan aliquam.",
        },
        {
            id: 2,
            title: "Norway",
            imageUrl: "http://fjordtravel.no/wp-content/uploads/2013/10/lofoten2-Andrea-Giubelli-Innovation-Norway-300x225.jpg",
            website: "http://www.norway.com",
            boardId: 1,
            shortDescription: "Love this place",
            longDescription: "Feugiat luctus elit, augue sodales lacus nibh sit. Enim arcu ultrices dictum pellentesque justo malesuada, pede eleifend, cras magna.",
        },
        {
            id: 3,
            title: "Cat",
            imageUrl: "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRPPGWyw4eLwSjHYVPVz-XLWCsZwvtFGoSXnGee1MVUDVEAIV5e",
            website: "http://www.cat.com",
            boardId: 2,
            shortDescription: "I want one!",
            longDescription: "Sed molestie hendrerit cras purus, vitae class, integer libero. Nec ullamcorper sed fermentum at id magni, risus metus, fermentum sapien eros aliquam dis neque vel, ligula nec lacinia.",
        },
        {
            id: 4,
            title: "Dog",
            imageUrl: "http://cutepuppyclub.com/wp-content/uploads/2015/05/White-Cute-Puppy--300x188.jpg",
            website: "http://www.dog.com",
            boardId: 2,
            shortDescription: "I need him!",
            longDescription: "Sed molestie hendrerit cras purus, vitae class, integer libero. Nec ullamcorper sed fermentum at id magni, risus metus, fermentum sapien eros aliquam dis neque vel, ligula nec lacinia.",
        }
            
    ];


    angular.module('QuinterestApp').controller('PinIndexController', function () {
        this.pins = pins;
    });


    angular.module('QuinterestApp').controller('PinDetailsController', function ($routeParams) {
        this.pin = pins.filter(function (item) {
            return item.id == $routeParams.id;
        })
    })[0];

    angular.module('QuinterestApp').controller('PinCreateController', function () {
        //change this!!! --> only temporary
        this.createPin = function () {
            console.dir(this.pin);
        };
    });


    angular.module('QuinterestApp').controller('BoardIndexController', function () {
        this.boards = boards;
    });


    angular.module('QuinterestApp').controller('BoardDetailsController', function ($routeParams) {
        this.pins = pins.filter(function (item) {
            return item.boardId == $routeParams.id;
        })

        this.board = boards.filter(function (item) {
            return item.id == $routeParams.id;
        })
    })[0];

    angular.module('QuinterestApp').controller('BoardCreateController', function () {
        //change this!!! --> only temporary
        this.createBoard = function () {
            console.dir(this.board);
        };
    });

})();