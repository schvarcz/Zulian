$(function () {
    function dist(pt1, pt2) {
        return Math.sqrt(Math.pow(pt2.x - pt1.x, 2) + Math.pow(pt2.y - pt1.y, 2))
    }
    $('#container').highcharts({
        chart: {
            type: 'scatter',
            margin: [70, 50, 60, 80],
            events: {
                click: function (e) {
                    // find the clicked values and the series
                    var x = e.xAxis[0].value,
                        y = e.yAxis[0].value,
                        series = this.series[0];

                    dataChart = series.data;
                    var xPt = 1000000;
                    var idx = -1;
                    for (i = 0; i < dataChart.length; i++) {
                        if (dist(dataChart[i], { x: x, y: y }) < xPt) {
                            xPt = dist(dataChart[i], { x: x, y: y });
                            idx = i;
                        }
                    }
                    dataChart[idx].update([x, y]);
                }
            }
        },
        title: {
            text: 'Fuzzy Viviane: A menina confusa!'
        },
        subtitle: {
            text: 'Clique próximo ao ponto para fazer ele atualizar a sua posição.'
        },
        xAxis: {
            gridLineWidth: 1,
            minPadding: 0.2,
            maxPadding: 0.2,
            maxZoom: 60
        },
        yAxis: {
            title: {
                text: 'Value'
            },
            minPadding: 0.2,
            maxPadding: 0.2,
            maxZoom: 60,
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        legend: {
            enabled: false
        },
        exporting: {
            enabled: false
        },
        plotOptions: {
            series: {
                lineWidth: 1,
            }
        },
        series: [{
            data: [[0, 0], [20, 20], [50, 20], [70, 0]]
        }]
    });
});