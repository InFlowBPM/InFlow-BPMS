/// <reference path="/Scripts/jquery.jsPlumb-1.5.5-min" />


function updateConfigPanel(action, routingvalues) {
    routingvalues.edit = Edit;
    $.ajax({
        url: URL+"Pdesigner/" + action,
        data: routingvalues,
        type: 'GET',
        success: function (data) {
            $('#pdesignerconfig').html(data);
        }
    });
    $('#pdesignerconfig').css({'top':mouseY});
}

function clearConfigPanel() {
    $('#pdesignerconfig').children().remove();;
}
var mouseY = 0;
$('#pdesignersubjectcontainer').mousemove(function (e) {
    var container = $('#pdesignersubjectcontainer');
    var y = container.offset().top;

    mouseY = Math.round(e.pageY - y);       
});

function getFromAPI(url) {
    var tmp;
    $.ajax({
        type: "GET",
        url: url,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            tmp = data;
        },
        error: function (error) {
            tmp = null;
        }
    });
    return tmp;
}

function postFromAPI(url, data) {
    var tmp;
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        async: false,
        success: function (da) {
            tmp = da;
        },
        dataType: "json"
    });
    return tmp;
}

function putFromAPI(url, data) {

    $.ajax({
        type: "PUT",
        url: url,
        data: data,
        async: false,
        success: function (da) {
            tmp = da;
        },
        dataType: "json"
    });
}

function deleteFromAPI(url) {
    var tmp;
    $.ajax({
        type: "DELETE",
        url: url,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            tmp = data;
        },
        error: function (error) {
            tmp = null;
        }
    });
    return tmp;
}


var movedTimes = 1;
jsPlumb.ready(function () {

    var EnableDrag = false;
    if (Edit == 1) {
        EnableDrag = true;
    }   

    var connectorTransitionPaintStyle = {
        lineWidth: 3,
        strokeStyle: "#000000",
        joinstyle: "round"
    };

    var connectorTimeoutPaintStyle = {
        lineWidth: 3,
        strokeStyle: "red",
        joinstyle: "round"
    };

    var sourceRegularTransitionOption = {
        isSource: EnableDrag,
        anchor: 'Continuous',
        connectorStyle: connectorTransitionPaintStyle,
        connectorOverlays: [["Arrow", { location: 1 }],
            ["Label", { label: "Transition", cssClass: "pdesignertransitionLabel", id: "label", location: 0.5 }]],
        paintStyle: {
            strokeStyle: "#000000",
            fillStyle: "transparent",
            radius: 6,
            lineWidth: 3
        },
        connector: ["Flowchart", { stub: [10, 30], gap: 6, cornerRadius: 5, alwaysRespectStubs: true }],
        parameters: { "type": 0, "id": -1 },
    };

    var sourceReceiveTransitionOption = {
        isSource: EnableDrag,
        anchor: 'Continuous',
        connectorStyle: connectorTransitionPaintStyle,
        connectorOverlays: [["Arrow", { location: 1 }],
            ["Label", { label: "Receive", cssClass: "pdesignertransitionLabel", id: "label", location: 0.5 }]],
        paintStyle: {
            strokeStyle: "#000000",
            fillStyle: "transparent",
            radius: 6,
            lineWidth: 3
        },
        connector: ["Flowchart", { stub: [10, 30], gap: 6, cornerRadius: 5, alwaysRespectStubs: true }],
        parameters: { "type": 2, "id": -1 },
    };

    var sourceTimeoutOption = {
        isSource: EnableDrag,
        anchor: 'BottomLeft',
        connectorStyle: connectorTimeoutPaintStyle,
        connectorOverlays: [["Arrow", { location: 1 }],
            ["Label", { label: "TimeOut", cssClass: "pdesignertransitionLabel", id: "label", location: 0.5 }]],
        paintStyle: {
            strokeStyle: "#000000",
            fillStyle: "transparent",
            radius: 6,
            lineWidth: 3
        },
        connector: ["Flowchart", { stub: [10, 30], gap: 6, cornerRadius: 5, alwaysRespectStubs: true }],
        parameters: { "type": 1, "id": -1 },
    };

    var targetOption = {
        anchor: 'Continuous',
        isTarget: EnableDrag,
        paintStyle: {
            strokeStyle: "#000000",
            fillStyle: "transparent",
            radius: 6,
            lineWidth: 3
        }
    };

    var canvas = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/Canvas/");
    if (canvas.CanvasHeight == 0 && canvas.CanvasWidth == 0) {
        canvas.CanvasWidth = 680;
        canvas.CanvasHeight = 600;
    }
    $('#pdesignersubjectcontainer').css({
        'width': canvas.CanvasWidth,
        'height': canvas.CanvasHeight
    });

    var states = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/");
    //var movedTimes = 1;

    $.each(states, function (i, item) {
        addState('#pdesignersubjectcontainer', item);
    });

    var transitions = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/Transitions/");

    $.each(transitions, function (i, item) {
        addTransition('#pdesignersubjectcontainer', item);
    });

    function makeBigger(info) {
        var conTarget = jsPlumb.getEndpoints(info.targetId).length;
        var currentElement = document.getElementById(info.targetId);
        if (conTarget > 6) {
            currentElement.style.height = '120px'; currentElement.style.width = '140px';
            document.getElementById("pdesignertransition" + info.targetId.replace("pdesignerstate", "")).style.width = '90px';
        }
        var conSource = jsPlumb.getEndpoints(info.sourceId).length + 1;
        currentElement = document.getElementById(info.sourceId);
        if (conSource > 6) {
            currentElement.style.height = '120px'; currentElement.style.width = '140px';
            document.getElementById("pdesignertransition" + info.sourceId.replace("pdesignerstate", "")).style.width = '90px';
        }
        jsPlumb.repaintEverything();
    }


    //Transition events
    jsPlumb.bind("connection", function (info, originalEvent) {        
        var id = info.connection.getParameter("id");
        var same = (info.targetId == info.sourceId);
        if (id == -1 && !same) {
            createTransition(info);
        }
        else {
            if (!same) {
                updateTransition(info);
            } else {
                jsPlumb.detach(info.connection);
                //jsPlumb.detachAllConnections(info.sourceId);
                /*
                $.each(transitions, function (i, item) {
                    var a = "pdesignerstate" + item.Source;
                    var b = "pdesignerstate" + item.Target;
                    if (a == info.sourceId || b == info.sourceId) {}
                });*/
                $('#myModal').modal('toggle');
                $('#myModal').modal('show');
                //jsPlumb.deleteEndpoint(info.targetEndpoint);
                //jsPlumb.deleteEndpoint(info.sourceEndpoint);
            }
        }
        makeBigger(info);
    });


    jsPlumb.bind("connectionDetached", function (info, originalEvent) {
        removeTransition(info.connection.getParameter("id"), info.connection.getParameter("type"));

        var currentElement = document.getElementById(info.targetId);
        var conTarget = jsPlumb.getEndpoints(info.targetId).length -1;
        if (conTarget <= 6) {
            currentElement.style.removeProperty("width"); currentElement.style.removeProperty("height");
            document.getElementById("pdesignertransition" + info.targetId.replace("pdesignerstate", "")).style.removeProperty("width");
        }
        currentElement = document.getElementById(info.sourceId);
        var conSource = jsPlumb.getEndpoints(info.sourceId).length -1;
        if (conSource <= 6) {
            currentElement.style.removeProperty("width"); currentElement.style.removeProperty("height");
            document.getElementById("pdesignertransition" + info.sourceId.replace("pdesignerstate", "")).style.removeProperty("width");
        }
    });

 
    $('#pdesignersubjectcontainer').dblclick(function (e) {
        if (Edit == 1) {
            var tool = $('#pdesignertools :selected').text();
            var type;

            if (tool == "Function") {
                type = 0;
            }
            if (tool == "Send") {
                type = 1;
            }
            if (tool == "Receive") {
                type = 2;
            }
            if (tool == "Refinement") {
                type = 3;
            }
            var container = $('#pdesignersubjectcontainer');
            var x = container.offset().left;
            var y = container.offset().top;
            x = Math.round(e.pageX - x);
            y = Math.round(e.pageY - y);
            var info = createState(type, x - x % 20, y - y % 20);
            addState('#pdesignersubjectcontainer', info)
        }
    });

    function addTransition(subject, transitioninfo) {
        var c;
        //Regular
        if (transitioninfo.Type == 0) {
            var e1 = jsPlumb.addEndpoint("pdesignerstate" + transitioninfo.Source, sourceRegularTransitionOption);
            e1.setEnabled(EnableDrag);
            var e2 = jsPlumb.addEndpoint("pdesignerstate" + transitioninfo.Target, targetOption);
            e2.setEnabled(EnableDrag);

            c = jsPlumb.connect({
                source: e1,
                target: e2,
                parameters: { "type": transitioninfo.Type, "id": transitioninfo.Id },
                overlays: [["Diamond", { location: 0, id: "diamond", events: { "click": function (label, evt) { var now = c.getOverlay("label").getLocation(); if (now >= 0.8) c.getOverlay("label").setLocation(0.1); else c.getOverlay("label").setLocation(now + 0.1); updateTransitionLabelPos(transitioninfo,c.getOverlay("label").getLocation()) } } }]],
                deleteEndpointsOnDetach: true
            });
        } 
        //Reveive
        if (transitioninfo.Type == 2) {
            var e1 = jsPlumb.addEndpoint("pdesignerstate" + transitioninfo.Source, sourceReceiveTransitionOption);
            e1.setEnabled(EnableDrag);
            var e2 = jsPlumb.addEndpoint("pdesignerstate" + transitioninfo.Target, targetOption);
            e2.setEnabled(EnableDrag);

            c = jsPlumb.connect({
                source: e1,
                target: e2,
                parameters: { "type": transitioninfo.Type, "id": transitioninfo.Id },
                overlays: [["Diamond", { location: 0, id: "diamond", events: { "click": function (label, evt) { var now = c.getOverlay("label").getLocation(); if (now >= 0.8) c.getOverlay("label").setLocation(0.1); else c.getOverlay("label").setLocation(now + 0.1); updateTransitionLabelPos(transitioninfo,c.getOverlay("label").getLocation()) } } }]],
                deleteEndpointsOnDetach: true
            });
        }
        //Timeout
        if (transitioninfo.Type == 1) {
            var e1 = jsPlumb.addEndpoint("pdesignerstate" + transitioninfo.Source, sourceTimeoutOption);
            e1.setEnabled(EnableDrag);
            var e2 = jsPlumb.addEndpoint("pdesignerstate" + transitioninfo.Target, targetOption);
            e2.setEnabled(EnableDrag);

            c = jsPlumb.connect({
                source: e1,
                target: e2,
                parameters: { "type": transitioninfo.Type, "id": transitioninfo.Id },
                overlays: [["Diamond", { location: 0, id: "diamond", events: { "click": function (label, evt) { var now = c.getOverlay("label").getLocation(); if (now >= 0.8) c.getOverlay("label").setLocation(0.1); else c.getOverlay("label").setLocation(now + 0.1); updateTransitionLabelPos(transitioninfo,c.getOverlay("label").getLocation()) } } }]],
                deleteEndpointsOnDetach: true
            });
        }

        c.getOverlay("label").setLabel(transitioninfo.Label);
        c.getOverlay("label").setLocation(transitioninfo.LabelPosition);
        jsPlumb.bind('click', function (c, e) {
            var tid = c.getParameter("id");
            updateConfigPanel("_EditTransition", { "processid": processId, "subjectid": subjectId, "transitionid": tid });
            
        });
        makeBigger(c);
    }

    function addState(subject, stateinfo) {
        var newState;
        
        if (stateinfo.Type == 0) {
            newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');

            newState.addClass('pdesignerfunction');
            newState.append('<span class="glyphicon glyphicon-arrow-right"></span>')

        }
        if (stateinfo.Type == 1) {
            newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');
            newState.addClass('pdesignersend');
            newState.append('<span class="glyphicon glyphicon-arrow-up"></span>')

        }
        if (stateinfo.Type == 2) {
            newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');
            newState.addClass('pdesignerreceive');
            newState.append('<span class="glyphicon glyphicon-arrow-down"></span>')

        }
        if (stateinfo.Type == 3) {
            newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');
            newState.addClass('pdesignerref');
            newState.append('<span class="glyphicon glyphicon-cog"></span>')

        }
        if (stateinfo.EndState) {
            newState.append('<span class="glyphicon glyphicon-stop"></span>')

        }
        if (stateinfo.StartState) {

            newState.append('<span class="glyphicon glyphicon-play"></span>')

        }
        $(newState).attr("title", stateinfo.Name);
        var title = $('<div>').addClass('pdesignertitle').text(stateinfo.Name);

        //check if position is in use
        /*$.each(states, function (i, item) {
            if (item.PositionLeft == stateinfo.PositionLeft  && item.PositionTop == stateinfo.PositionTop){
                if (item.Id != stateinfo.Id) {
                    stateinfo.PositionTop += 80*movedTimes;
                    stateinfo.PositionLeft += 80*movedTimes;
                    movedTimes++;
                }
            }            
        });*/
        newState.css({            
            'top': stateinfo.PositionTop,
            'left': stateinfo.PositionLeft
        });
        if (stateinfo.PositionTop == 0) {
            stateinfo.PositionTop += (Math.random() * 600);
            stateinfo.PositionLeft += (Math.random() * 500);
            newState.css({
                'top': stateinfo.PositionTop,
                'left': stateinfo.PositionLeft
            });
            stateMoved(newState.attr("id").replace("pdesignerstate", ""), newState.css("left"), newState.css("top"));
        }

        var timeout = $('<div>').addClass('pdesignertimeout');
        newState.append(title);
        
        if (EnableDrag) {
            jsPlumb.makeTarget(newState, targetOption);

            if (stateinfo.Type == 2) {
                var transition = $('<div>').attr('id', 'pdesignertransition' + stateinfo.Id).addClass('pdesignerreceivetransition');
                jsPlumb.makeSource(transition, { parent: newState }, sourceReceiveTransitionOption);
            }
            else {
                var transition = $('<div>').attr('id', 'pdesignertransition' + stateinfo.Id).addClass('pdesignerregulartransition');
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var milabel = "Transition";
                var messages = getFromAPI(apiURL + processId + "/Messages");
                $.each(messages, function (i, item) {
                    if (stateinfo.Message == item.Id) milabel = item.TypeName;
                });
                var sourceRegularTransitionOption2 = {
                    isSource: EnableDrag,
                    anchor: 'Continuous',
                    connectorStyle: connectorTransitionPaintStyle,
                    connectorOverlays: [["Arrow", { location: 1 }],
                        ["Label", { label: milabel, cssClass: "pdesignertransitionLabel", id: "label" }]],
                    paintStyle: {
                        strokeStyle: "#000000",
                        fillStyle: "transparent",
                        radius: 6,
                        lineWidth: 3
                    },
                    connector: ["Flowchart", { stub: [10, 30], gap: 6, cornerRadius: 5, alwaysRespectStubs: true }],
                    parameters: { "type": 0, "id": -1 },
                };
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                jsPlumb.makeSource(transition, { parent: newState }, sourceRegularTransitionOption2);
              
            }

            jsPlumb.makeSource(timeout, { parent: newState }, sourceTimeoutOption);

            newState.append(timeout);
            newState.append(transition);

            jsPlumb.draggable(newState, {
                containment: 'parent',
             grid: [20, 20]
             });            
        }


        newState.click(function (e) {

            var stateid = $(this).attr("id").replace("pdesignerstate", "");
            updateConfigPanel("_EditState", { "processid": processId, "subjectid": subjectId, "stateid": stateid });
        })

        $(subject).append(newState);
        

        newState.mouseup(function () {
            var self = $(this);
            stateMoved(self.attr("id").replace("pdesignerstate", ""), self.css("left"), self.css("top"));
        });
        states = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/");
    }


    $('#pdesignersubjectcontainer').mouseup(function (e) {
        var self = $(this);
        canvasResized($('#pdesignersubjectcontainer').width(), $('#pdesignersubjectcontainer').height());
    });
    function canvasResized(x, y) {
        var data = {
            CanvasWidth: x,
            CanvasHeight: y
        }
        putFromAPI(apiURL + processId + "/subjects/" + subjectId + "/Canvas", data)
    }
    //Events:

    function deleteState(id) {
        $("#pdesignerlog").append("<li>delete state: " + id + "</li>");
        deleteFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/" + id);
        states = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/");
        if (movedTimes > 1) movedTimes--;
    }

    function createState(type, x, y) {
        
        var data = {
            Type: type,
            PositionTop: y,
            PositionLeft: x
        }
        var result = postFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States", data);
        $("#pdesignerlog").append("<li>created state: " + result.Id + "</li>");
        updateConfigPanel("_EditState", { "processid": processId, "subjectid": subjectId, "stateid": result.Id });
        return result;
    }

    function stateMoved(id, x, y) {
        var data = {
            Id: id,
            PositionTop: Math.round(y.replace("px", "")),
            PositionLeft: Math.round(x.replace("px", ""))
        }
        putFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/" + id, data)
        $("#pdesignerlog").append("<li>moved state: " + id + " to (" + data.PositionLeft + "," + data.PositionTop + ")</li>");
    }
    
    function createTransition(info) {
        var data = {
            Type: info.connection.getParameter("type"),
            Source: info.sourceId.replace("pdesignerstate", ""),
            Target: info.targetId.replace("pdesignerstate", ""),
            LabelPosition: 0.5
        }

        var result = postFromAPI(apiURL + processId + "/subjects/" + subjectId + "/Transitions", data);
        info.connection.setParameter("id", result.Id);
        var c = info.connection;
        c.addOverlay(["Diamond", { location: 0, id: "diamond", events: { "click": function (label, evt) { var now = c.getOverlay("label").getLocation(); if (now >= 0.8) c.getOverlay("label").setLocation(0.1); else c.getOverlay("label").setLocation(now + 0.1); var x = {Id: result.Id, Source: info.sourceId.replace("pdesignerstate", ""),  Target: info.targetId.replace("pdesignerstate", "") };updateTransitionLabelPos(x,c.getOverlay("label").getLocation()); } } }]);
        $("#pdesignerlog").append("<li>created transition: " + result.Id + "</li>");
        updateConfigPanel("_EditTransition", { "processid": processId, "subjectid": subjectId, "transitionid": result.Id });        
        jsPlumb.bind('click', function (c, e) {
            var tid = c.getParameter("id");
            updateConfigPanel("_EditTransition", { "processid": processId, "subjectid": subjectId, "transitionid": tid});
        });
    }

    function removeTransition(id, type) {
        deleteFromAPI(apiURL + processId + "/subjects/" + subjectId + "/Transitions/" + id);
        $("#pdesignerlog").append("<li>deleted transition: " + id + "(type: " + type + ")</li>");
    }

    function updateTransition(info) {
        var data = {
            Id: info.connection.getParameter("id"),
            Source: info.sourceId.replace("pdesignerstate", ""),
            Target: info.targetId.replace("pdesignerstate", ""),
            //LabelPosition: info.connection.getParameter("LabelPosition")
        }

        putFromAPI(apiURL + processId + "/Subjects/" + subjectId + "/Transitions/" + data.Id, data)
        $("#pdesignerlog").append("<li>transition " + data.Id + " moved:  (s: " + data.Source + " ,t: " + data.Target + ")</li>");
    }
    function updateTransitionLabelPos(info,labelpos) {
        var data = {
            Id: info.Id,
            Source: info.Source,
            Target: info.Target,
            LabelPosition: labelpos
        }
        putFromAPI(apiURL + processId + "/Subjects/" + subjectId + "/Transitions/" + data.Id, data)
        $("#pdesignerlog").append("<li>transition " + data.Id + " moved:  (s: " + data.Source + " ,t: " + data.Target + ")</li>");
    }
    jsPlumb.repaintEverything();
});
function createState(type, x, y) {

    var data = {
        Type: type,
        PositionTop: y,
        PositionLeft: x
    }
    var result = postFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States", data);
    $("#pdesignerlog").append("<li>created state: " + result.Id + "</li>");
    updateConfigPanel("_EditState", { "processid": processId, "subjectid": subjectId, "stateid": result.Id });
    addState('#pdesignersubjectcontainer',result);
}


/*
function addState(subject, stateinfo) {
    var newState;

    if (stateinfo.Type == 0) {
        newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');

        newState.addClass('pdesignerfunction');
        newState.append('<span class="glyphicon glyphicon-arrow-right"></span>')

    }
    if (stateinfo.Type == 1) {
        newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');
        newState.addClass('pdesignersend');
        newState.append('<span class="glyphicon glyphicon-arrow-up"></span>')

    }
    if (stateinfo.Type == 2) {
        newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');
        newState.addClass('pdesignerreceive');
        newState.append('<span class="glyphicon glyphicon-arrow-down"></span>')

    }
    if (stateinfo.Type == 3) {
        newState = $('<div>').attr('id', 'pdesignerstate' + stateinfo.Id).addClass('pdesignerstate');
        newState.addClass('pdesignerref');
        newState.append('<span class="glyphicon glyphicon-cog"></span>')

    }
    if (stateinfo.EndState) {
        newState.append('<span class="glyphicon glyphicon-stop"></span>')

    }
    if (stateinfo.StartState) {

        newState.append('<span class="glyphicon glyphicon-play"></span>')

    }

    var title = $('<div>').addClass('pdesignertitle').text(stateinfo.Name);


    newState.css({            
        'top': stateinfo.PositionTop,
        'left': stateinfo.PositionLeft
    });
    if (stateinfo.PositionTop == 0) {
        stateinfo.PositionTop += (Math.random() * 600);
        stateinfo.PositionLeft += (Math.random() * 500);
        newState.css({
            'top': stateinfo.PositionTop,
            'left': stateinfo.PositionLeft
        });
        stateMoved(newState.attr("id").replace("pdesignerstate", ""), newState.css("left"), newState.css("top"));
    }




    var timeout = $('<div>').addClass('pdesignertimeout');
    newState.append(title);

    if (EnableDrag) {
        jsPlumb.makeTarget(newState, targetOption);

        if (stateinfo.Type == 2) {
            var transition = $('<div>').attr('id', 'pdesignertransition' + stateinfo.Id).addClass('pdesignerreceivetransition');
            jsPlumb.makeSource(transition, { parent: newState }, sourceReceiveTransitionOption);
        }
        else {
            var transition = $('<div>').attr('id', 'pdesignertransition' + stateinfo.Id).addClass('pdesignerregulartransition');
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var milabel = "Transition";
            var messages = getFromAPI(apiURL + processId + "/Messages");
            $.each(messages, function (i, item) {
                if (stateinfo.Message == item.Id) milabel = item.TypeName;
            });
            var sourceRegularTransitionOption2 = {
                isSource: EnableDrag,
                anchor: 'Continuous',
                connectorStyle: connectorTransitionPaintStyle,
                connectorOverlays: [["Arrow", { location: 1 }],
                    ["Label", { label: milabel, cssClass: "pdesignertransitionLabel", id: "label" }]],
                paintStyle: {
                    strokeStyle: "#000000",
                    fillStyle: "transparent",
                    radius: 6,
                    lineWidth: 3
                },
                connector: ["Flowchart", { stub: [10, 30], gap: 6, cornerRadius: 5, alwaysRespectStubs: true }],
                parameters: { "type": 0, "id": -1 },
            };
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            jsPlumb.makeSource(transition, { parent: newState }, sourceRegularTransitionOption2);

        }

        jsPlumb.makeSource(timeout, { parent: newState }, sourceTimeoutOption);


        newState.append(timeout);
        newState.append(transition);

        jsPlumb.draggable(newState, {
            containment: 'parent',
            grid: [20, 20]
        });

    }


    newState.click(function (e) {

        var stateid = $(this).attr("id").replace("pdesignerstate", "");
        updateConfigPanel("_EditState", { "processid": processId, "subjectid": subjectId, "stateid": stateid });
    })

    $(subject).append(newState);


    newState.mouseup(function () {
        var self = $(this);
        stateMoved(self.attr("id").replace("pdesignerstate", ""), self.css("left"), self.css("top"));
    });
    states = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/");
}*/


function deleteState(id) {

    var item = $('#pdesignerstate' + id)
    jsPlumb.detachAllConnections(item);
    item.remove();

    $("#pdesignerlog").append("<li>delete state: " + id + "</li>");
    deleteFromAPI(apiURL + processId + "/Subjects/" + subjectId +"/States/" + id);

    clearConfigPanel();
    if (movedTimes > 1) movedTimes--;/*
    var result = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States");
    $.each(result, function (i, item2) {
        if(item2.Id>id) item2.Id = item2.Id - 1;
        alert(item2.Id);
    });*/
}




$('.window').resizable();

$('#pdesignerconfig').draggable();


$(document).ready(function() {  
    var stickyNavTop = $('.pdesignertools').offset().top;
     
    var stickyNav = function(){  
       var scrollTop = $(window).scrollTop();  
               
        if (scrollTop > stickyNavTop) {   
            $('.pdesignertools').addClass('sticky');
           } else {  
            $('.pdesignertools').removeClass('sticky');
       }  
    };  
stickyNav();  
  
$(window).scroll(function() {  
        stickyNav();  
    });  
});  


function resetSubject() {

    var states = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States/");

    $.each(states, function (i, item) {
        deleteState(item.Id);
    });

    var transitions = getFromAPI(apiURL + processId + "/subjects/" + subjectId + "/Transitions/");

    $.each(transitions, function (i, item) {
        removeTransition(item.Id);
    });

    clearConfigPanel();
}
