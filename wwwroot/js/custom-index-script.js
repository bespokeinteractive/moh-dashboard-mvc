/*
 * Dashboard - Analytics
 */

	// Polor chart data
	var doughnutData = [{
		value: 3000,
		color: "#F7464A",
		highlight: "#FF5A5E",
		label: "Tier1"
	}, {
		value: 500,
		color: "#46BFBD",
		highlight: "#5AD3D1",
		label: "Tier4"
	}, {
		value: 1000,
		color: "#FDB45C",
		highlight: "#FFC870",
		label: "Tier3"
	}, {
        value: 1000,
        color: "#ab47bc",
        highlight: "#ab47bc",
        label: "Tier4"
    }];


	// Trending Bar Chart	
	var dataBarChart = {
		labels: ["J", "F", "M", "A", "M", "J", "J", "A"],
		datasets: [{
			label: "Bar dataset",
			fillColor: "#46BFBD",
			strokeColor: "#46BFBD",
			highlightFill: "rgba(70, 191, 189, 0.4)",
			highlightStroke: "rgba(70, 191, 189, 0.9)",
			data: [6, 19, 8, 4, 6, 7, 9, 4]
		}]
	};

	var nReloads1 = 0;
	var min1 = 1;
	var max1 = 10;
	var l1 = 0;
	var trendingBarChart;

	function updateBarChart() {
		if (typeof trendingBarChart != "undefined") {
			nReloads1++;
			var x = Math.floor(Math.random() * (max1 - min1 + 1)) + min1;
			trendingBarChart.addData([x], dataBarChart.labels[l1]);
			trendingBarChart.removeData();
			l1++;
			if (l1 == dataBarChart.labels.length) {
				l1 = 0;
			}
		}
	}
	setInterval(updateBarChart, 5000);


	// Trending Bar chart	data
	var radarChartData = {
		labels: ["Tier 1", "Tier 2", "Tier 3", "Tier 4", "Others"],
		datasets: [{
			label: "First dataset",
			fillColor: "rgba(255,255,255,0.2)",
			strokeColor: "#fff",
			pointColor: "#00796b",
			pointStrokeColor: "#fff",
			pointHighlightFill: "#fff",
			pointHighlightStroke: "#fff",
			data: [5, 6, 7, 8, 6]
		}],
	};


	var nReloads2 = 0;
	var min2 = 1;
	var max2 = 10;
	var l2 = 0;
	var trendingRadarChart;

	function trendingRadarChartupdate() {
		if (typeof trendingRadarChart != "undefined") {
			nReloads2++;
			var x = Math.floor(Math.random() * (max2 - min2 + 1)) + min2;
			trendingRadarChart.addData([x], radarChartData.labels[l2]);
			var y = trendingRadarChart.removeData();
			l2++;
			if (l2 == radarChartData.labels.length) {
				l2 = 0;
			}
		}
	}
	setInterval(trendingRadarChartupdate, 5000);

	// Line Chart Data	
	var lineChartData = {
		labels: ["LV1", "LV2", "LV3", "LV4", "LV5", "LV6"],
		datasets: [{
			label: "My dataset",
			fillColor: "rgba(255,255,255,0)",
			strokeColor: "#fff",
			pointColor: "#00796b ",
			pointStrokeColor: "#fff",
			pointHighlightFill: "#fff",
			pointHighlightStroke: "rgba(220,220,220,1)",
			data: [65, 88, 55, 80, 23, 15]
		}]

	}

$(window).on('load', function() {
	// Doughnut Chart - use data var = doughnutData  
	var doughnutChart = document.getElementById("doughnut-chart").getContext("2d");
	window.myDoughnut = new Chart(doughnutChart).Doughnut(doughnutData, {
		segmentStrokeColor: "#fff",
		tooltipTitleFontFamily: "'Roboto','Helvetica Neue', 'Helvetica', 'Arial', sans-serif", // String - Tooltip title font declaration for the scale label		
		percentageInnerCutout: 50,
		animationSteps: 15,
		segmentStrokeWidth: 4,
		animateScale: true,
		percentageInnerCutout: 60,
		responsive: true
	});

    // Line Chart = use data var lineChartData
    var lineChart = document.getElementById("line-chart").getContext("2d");
    window.lineChart = new Chart(lineChart).Line(lineChartData, {
        scaleShowGridLines: false,
        bezierCurve: false,
        scaleFontSize: 12,
        scaleFontStyle: "normal",
        scaleFontColor: "#fff",
        responsive: true,
    });
});



