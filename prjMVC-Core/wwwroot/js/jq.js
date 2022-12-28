$("#chat").hover(function () {
    $("#left-eye").css({ "top": "30%", "left": "25% ", "transition": ".4s" });
    $("#right-eye").css({ "top": "30%", "right": "25% ", "transition": ".4s" });
    $("#mouth").css({ "left": "38% ", "top": "50%", "width": "15px", "height": "10px", "border-radius": "0 0 50px 50px", "transition": ".4s" });
},
    function () {
        $("#left-eye").css("background", "white")
        $("#left-eye").css({ "top": "45%", "left": "19% ", "transition": ".4s" });
        $("#right-eye").css({ "top": "45%", "right": "19% ", "transition": ".4s" });
        $("#mouth").css({ "left": "45%", "top": "45%", "width": "6px", "height": "6px", "border-radius": "50px", "transition": ".4s" });
    })