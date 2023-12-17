
// Active class script

$(".sidebar-nav .nav-item .nav-link").click(function(){
  $(".sidebar-nav .nav-item .nav-link").removeClass('active');
  $(this).addClass('active');
  $(".sidebar-nav .nav-item .nav-link").addClass('collapsed');
  $(".sidebar-nav .nav-content").addClass('collapse');
});

$(".sidebar-nav .nav-content a").click(function(){
  $(".sidebar-nav .nav-content a").removeClass('active');
  $(this).addClass('active');
});


// Side Navigation Script

(function($) {

	"use strict";
    
	$('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
  });

})(jQuery);

$(document).ready(function() {
    $('[data-toggle=offcanvas]').click(function() {
             $('.tgl-side-menu').toggleClass('active');
    });
 });

    $('.ta').click(function() {
    $(this).toggleClass('active');
});

  