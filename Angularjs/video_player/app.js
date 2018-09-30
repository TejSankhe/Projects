
(function() {

  'use strict';


  angular.module('app',[])
    .directive('videoDirective', VideoDirective)
	
	function VideoDirective()
	{
		var ddo={
			scope: true,
			templateUrl:'videotemplate.html',
			 link: VideoDirectivelink, 
			 controller: VideoDirectiveController,
             controllerAs: 'list',
             bindToController: true,
			 transclude :true
			
			
		};
		return ddo;
	}
 function VideoDirectivelink(scope, element, attrs, controller,transclude) {

 var myVideo = element.find("video");
 controller.myVideo=myVideo;
 console.log(controller.myVideo);
/*  element.find("video")[0].append(transclude()); */
/* var ele=element.find("button");

console.log(element.find("button"));
console.log(ele[0]);
ele.on('click',controller.playPause()); */

} 
function VideoDirectiveController() {
  var vid = this;
  vid.myVideo=null;

 vid.playPause=function() { 
 
    if (vid.myVideo[0].paused) 
         vid.myVideo[0].play(); 
	
    else 
		vid.myVideo[0].pause(); 
	
         
} 

vid.makeBig=function () { 
	vid.myVideo[0].width = 560; 
} 

vid.makeSmall=function() { 
    vid.myVideo[0].width = 320; 
} 

vid.makeNormal=function() { 
    vid.myVideo[0].width = 420; 
}
}
})();