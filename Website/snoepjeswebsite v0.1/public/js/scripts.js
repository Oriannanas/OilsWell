jQuery(document).ready(function($){
    spawn();
    function spawn(){
        $("#left-side").empty();
        $("#right-side").empty();
        if($(window).width() > 1300){
        var maxCandy = 20;
        var image1 = "/snoepjeswebsite/public/images/candy1.png";
        var image2 = "/snoepjeswebsite/public/images/candy2.png";
        var image3 = "/snoepjeswebsite/public/images/candy3.png";
        var image4 = "/snoepjeswebsite/public/images/candy4.png";
        var image5 = "/snoepjeswebsite/public/images/candy5.png";
        var image6 = "/snoepjeswebsite/public/images/candy6.png";
        var image7 = "/snoepjeswebsite/public/images/candy7.png";
        var columnWidth = $("#left-side").width();
        var columnHeight = $("#left-side").height();
        for (var i = 0; i < 3; i++){
        $("#left-side").append("<img src='"+image1+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#left-side").append("<img src='"+image2+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#left-side").append("<img src='"+image3+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#left-side").append("<img src='"+image4+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#left-side").append("<img src='"+image5+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#left-side").append("<img src='"+image6+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#left-side").append("<img src='"+image7+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image1+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image2+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image3+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image4+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image5+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image6+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        $("#right-side").append("<img src='"+image7+"' style='left:"+Math.round(Math.random()*(columnWidth-100))+";top:"+Math.round(Math.random()*(columnHeight-100))+";position:absolute;transform: rotate("+Math.floor(Math.random()*360)+"deg);' />")
        }
    }
    }
    $( window ).resize(function() {
    spawn();
});
});
