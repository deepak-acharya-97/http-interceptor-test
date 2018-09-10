// var request = require('request');

// request.get(
//     'http://www.yoursite.com/formpage',
//     { json: { key: 'value' } },
//     function (error, response, body) {
//         if (!error && response.statusCode == 200) {
//             console.log(body)
//         }
//     }
// );
// var http = require('http');
// http.get({
//     hostname: 'localhost',//'172.23.238.180',
//     port: 5001,
//     path: 'api/roadmaps',
//     agent: false  // create a new agent just for this one request
//   }, (res) => {
//     // Do stuff with response
//     console.log(res);
//   });

// request.get('http://172.23.238.180:5000/api/roadmaps', function (err, res, body) {
//     if (err) {
//         console.log(err);
//         console.log("Error");
//     }//TODO: handle err
//     else if (res.statusCode !== 200) {
//         console.log("Error")
//     } else {
//         console.log(body);
//     }
//     //etc
//     //TODO Do something with response
// });

var request = require('request');



let options = {
    url: 'http://172.23.238.180:5000/api/assignedtasks',
    json: {
        // "GroupName": "#random",
        // "MileStones": [{
        //     "MileStoneName": "Requirement Analysis"
        // }]
        "GroupName": "#general",
        "TaskName": "Design",
        "TaskAssigned": "Some Random Person"
    }
};

request.post(options, function (err, res, body) {
    console.log(res.statusCode);
    //console.log(body);
});