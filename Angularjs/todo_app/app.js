(function () {
'use strict';

angular.module("app", ['ui.router'])
.controller("ToDoController", ToDoController)
.config(RouteConfig)
.directive("cance1text",cance1text);

RouteConfig.$inject = ['$stateProvider', '$urlRouterProvider'];
function RouteConfig($stateProvider, $urlRouterProvider) {

  // Redirect to tab 1 if no other URL matches
  $urlRouterProvider.otherwise('/all');

  // Set up UI states
  $stateProvider
  .state('button1', {
	  url:'/all',
      templateUrl: 'All.html'
    })
    .state('button2', {
		 url:'/active',
      templateUrl: 'Active.html'
    })

    .state('button3', {
		 url:'/complete',
 templateUrl: 'Complete.html'
    });
}


function ToDoController()
{
	/* this.count = 0;
    this.myFunc = function() {
        this.count++;
    };
	this.list=[{name: 'choice1'}, {name: 'choice2'}, {name: 'choice3'}];
	list.push({name:this.task}); */
	this.s=[];
	this.list=[];
	this.addtask=function ()
	{
		if(this.task!="")
		{
			var task=
			{
				name:this.task,
				set:"true"
			}
		this.list.push(task);
		this.task="";
		}
	}
	this.ChangeSetValue=function(task)
	{
		if(task.set==='true')
		task.set="false";
	else
		task.set="true";
	}
	
	this.removetask=function (index)
	{
		this.list.splice(index,1);
	}


this.d =function(index)
                {
                                
                                /* console.log($('input.ab')[0].checked); */
                                console.log(index);
                                /* for(var i=0;i<this.list.length;i++)
                                {
                                               this.s[i]=$('input.ab')[i].checked;
                                } */
                                this.s[index]=$('input.ab')[index].checked;
                                
                                //return true;
                }
}
function cance1text()
{
		
	return {
		restrict: 'E',
		scope:
		{
			seeCheck:'='
		},
		link:StrikeTextfunction
	}
}

function StrikeTextfunction(scope, element, attrs, controller)
{
	var flag=0;
	
	//console.log(attrs.seeCheck.set);
	element.find("input").on('click',function(){
		if(flag)
		{
			//console.log(attrs.seeCheck);
			element.removeClass('strikeclass');
			flag=0;
			//attrs.seeCheck='false';
			
			//console.log("after "+attrs.seeCheck);
			
		}
		else{
			//console.log(attrs.seeCheck);
		element.addClass('strikeclass');
		//attrs.seeCheck='true';
		flag=1;
		}
	});
}
})();
