// JavaScript Document
var main = function(){
	"use strict";

	$('#DYK').text("Protection Services at UJ is responisble for storing all lost student cards.");
	
	$('.btnGetStarted').hover(function(){
	
		$('.lblGetStarted').css("color","white");
		
	}, function(){
		
		$('.lblGetStarted').css("color","#3F3F3F");
		
	});
	
	$('.btnGo').click(function(){
		document.getElementById('Clicked').innerHTML="Clicked";
		
		$('.btnGo').css("background-image","url(load.gif)");
	});
	
	$('.btnGoX').click(function(){
		//document.getElementById('Clicked').innerHTML="Clicked";
		
		//$('.btnGoX').css("background-image","url(load.gif)");
	});
	
	$('.btnGoX').click(function(){
		if(counter %2 === 0)
		{
			document.getElementById('Clicked').innerHTML="Clicked";
			$('.btnGoX').css("background-image","url(load.gif)");
			counter = 1;
			if(counter %2 === 0)
		{
			$('.Checkbox').addClass('isChecked');	
		}
		else
		{
			$('.Checkbox').removeClass('isChecked');	
		}
		}
	});
	
	var counter = 1;
	$('.Checkbox').click(function(){
		counter++;
		
		if(counter %2 === 0)
		{
			$('.Checkbox').addClass('isChecked');	
		}
		else
		{
			$('.Checkbox').removeClass('isChecked');	
		}
	});

	var ArrQuotes = [
	"All UJ campuses experience the same type of problems with student cards.",
	"Students at UJ rate the importance of student card to be 8/10.",
	"Students at UJ think that the price of R150 for new card is very expensive?",
	"Less than 40% of students find their cards back.",
	"A student card is very important tool for students at UJ.",
	"90% of lost student cards are lost because of negligence"
	];
	
	var QCounter = 0;
	var MAXVALUE = 6;
	var MINVALUE = -1;
	
	var RESET_MAX = 0;
	var RESET_MIN = 5;

	$('.next').click(function(){
	QCounter++;
	$('#DYK').text(ArrQuotes[QCounter]);

	if(QCounter === MAXVALUE)
	{
	  QCounter = RESET_MAX;
	$('#DYK').text(ArrQuotes[QCounter]);

	}
	});

	$('.prev').click(function(){
	QCounter--;
	$('#DYK').text(ArrQuotes[QCounter]);

	if(QCounter === MINVALUE)
	{
	  QCounter = RESET_MIN;
	$('#DYK').text(ArrQuotes[QCounter]);

	}
	});
};


$(document).ready(main);
	
	
	
	
