(function($){
 	$.fn.extend({  		
	    //pass the options variable to the function
		percentcircle: function(options) {
		//Set the default values, use comma to separate the settings, example:
			var defaults = {
			        animate : true,
					diameter : 100,
					guage: 2,
					coverBg: '#fff',
					bgColor: '#efefef',
					fillColor: '#5c93c8',
					percentSize: '15px',
					percentWeight: 'normal'
				},
				styles = {
				    cirContainer : {
					    'width':defaults.diameter,
						'height':defaults.diameter
					},
					cir : {
					    'position': 'relative',
					    'text-align': 'center',
					    'width': defaults.diameter,
					    'height': defaults.diameter,
					    'border-radius': '100%',
					    'background-color': defaults.bgColor,
					    'background-image' : 'linear-gradient(91deg, transparent 50%, '+defaults.bgColor+' 50%), linear-gradient(90deg, '+defaults.bgColor+' 50%, transparent 50%)'
					},
					cirCover: {
						'position': 'relative',
					    'top': defaults.guage,
					    'left': defaults.guage,
					    'text-align': 'center',
					    'width': defaults.diameter - (defaults.guage * 2),
					    'height': defaults.diameter - (defaults.guage * 2),
					    'border-radius': '100%',
					    'background-color': defaults.coverBg
					},
					percent: {
						'display':'block',
						'width': defaults.diameter,
					    'height': defaults.diameter,
					    'line-height': defaults.diameter + 'px',
					    'vertical-align': 'middle',
					    'font-size': defaults.percentSize,
					    'font-weight': defaults.percentWeight,
					    'color': defaults.fillColor
                    }
				};
			
			var that = this,
					template = '<div><div class="ab"><div class="cir"><span class="perc">{{percentage}}</span></div></div></div>',					
					options =  $.extend(defaults, options)					

			function init(){
				that.each(function(){
					var $this = $(this),
    					perc = Math.round($this.data('percent')),
                        colr = '',
                        deg = perc * 3.6,
                        stop = options.animate ? 0 : deg,
                        $chart = $(template.replace('{{percentage}}',perc+'%'));
                        $chart.css(styles.cirContainer).find('.ab').css(styles.cir).find('.cir').css(styles.cirCover).find('.perc').css(styles.percent);
                    if(perc <= 15){
                        colr = '#F00';
                    }
                    else if(perc < 30){
                        colr = '#E95546'
                    }
                    else if(perc < 45){
                        colr = '#D870A9'
                    }
                    else if(perc < 60){
                        colr = '#5C93C8'
                    }
                    else if(perc < 75){
                        colr = '#46CFB0'
                    }
                    else{
                        colr = '#8BC163'
                    }

					$this.prepend($chart); //add the chart back to the target element
					setTimeout(function(){
						animateChart(deg,parseInt(stop),colr,$chart.find('.ab')); //both values set to the same value to keep the function from looping and animating	
					},250)
	   	    	});
			}

			var animateChart = function (stop,curr,colr,$elm){
				var deg = curr;
				if(curr <= stop){
					if (deg>=180){
                        $elm.css('background-image','linear-gradient(' + (90+deg) + 'deg, transparent 50%, '+colr+' 50%),linear-gradient(90deg, '+colr+' 50%, transparent 50%)');
                    }else{
                        $elm.css('background-image','linear-gradient(' + (deg-90) + 'deg, transparent 50%, '+options.bgColor+' 50%),linear-gradient(90deg, '+colr+' 50%, transparent 50%)');
                    }

					curr ++;
					setTimeout(function(){
						animateChart(stop,curr,colr,$elm);
					},1);
				}
			};			
			
			init(); //kick off the goodness
   	    }
	});
	
})(jQuery);