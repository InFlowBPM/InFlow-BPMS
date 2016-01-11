/// <reference path="/Scripts/jquery.jsPlumb-1.5.5-min" />


function updateConfigPanel(action, routingvalues)
{
    routingvalues.edit= Edit;
    $.ajax({
        url: URL+"PDesigner/"+action,
        data: routingvalues,
        type: 'GET',
        success: function (data) {
            $('#pdesignerconfig').html(data);
        }
    });
}

function clearConfigPanel()
{
    $('#pdesignerconfig').children().remove();;
}

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


jsPlumb.ready(function () {

    var dynamicAnchors = [[0.2, 1, 0, 1], [0.5, 1, 0, 1], [0.8, 1, 0, 1],
                        [0.2, 0, 0, 1], [0.5, 0, 0, 1], [0.8, 0, 0, 1],
//                           [0, 0.1, 0, 1], [0, 0.2, 0, 1], [0, 0.3, 0, 1], [0, 0.4, 0, 1], [0, 0.5, 0, 1], [0, 0.6, 0, 1], [0, 0.7, 0, 1], [0, 0.8, 0, 1], [0, 0.9, 0, 1],
                          [0, 0.1, 0, 1], [0, 0.15, 0, 1], [0, 0.2, 0, 1], [0, 0.25, 0, 1], [0, 0.3, 0, 1], [0, 0.35, 0, 1], [0, 0.4, 0, 1], [0, 0.45, 0, 1], [0, 0.5, 0, 1], [0, 0.55, 0, 1], [0, 0.6, 0, 1], [0, 0.65, 0, 1], [0, 0.7, 0, 1], [0, 0.75, 0, 1], [0, 0.8, 0, 1], [0, 0.85, 0, 1], [0, 0.9, 0, 1],
                           [1, 0.1, 0, 1], [1, 0.15, 0, 1], [1, 0.2, 0, 1], [1, 0.25, 0, 1], [1, 0.3, 0, 1], [1, 0.35, 0, 1], [1, 0.4, 0, 1], [1, 0.45, 0, 1], [1, 0.5, 0, 1], [1, 0.55, 0, 1], [1, 0.6, 0, 1], [1, 0.65, 0, 1], [1, 0.7, 0, 1], [1, 0.75, 0, 1], [1, 0.8, 0, 1], [1, 0.85, 0, 1], [1, 0.9, 0, 1]
    ];
    //anchor: 'Continuous',
    var EnableDrag = false;
    if (Edit == 1)
    {
        EnableDrag = true;
    }

	var connectorMessageStyle = {
		lineWidth: 3,
		strokeStyle: "#0070c0"
	};

	var sourceMessageOption = {
	    isSource: EnableDrag,
	    anchor: 'Continuous',
		connectorStyle: connectorMessageStyle,
		connectorOverlays: [["Arrow", { location: 1 }],
            ["Label", { label: "Message", cssClass: "pdesignermessageLabel", id: "label" }]],
		paintStyle: {
			strokeStyle: "#000000",
			fillStyle: "transparent",
			radius: 6,
			lineWidth: 3
		},
		connector: ["StateMachine", { curviness: 10 }],
		parameters: { "id": -1 },
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

	var subjects = getFromAPI(apiURL +  processId + "/Subjects");
	$.each(subjects, function (i, item) {
	    addSubject('#pdesignercontainer', item);

	});

	var messages = getFromAPI(apiURL + processId + "/Messages");    
	$.each(messages, function (i, item) {
	    addMessage(item);
	});

	var canvas = getFromAPI(apiURL + processId + "/Canvas/");

	if (canvas.CanvasHeight == 0 && canvas.CanvasWidth == 0) {
	    canvas.CanvasWidth = 680;
	    canvas.CanvasHeight = 600;
	}
	$('#pdesignercontainer').css({
	    'width': canvas.CanvasWidth,
	    'height': canvas.CanvasHeight
	});


    //Message events
	jsPlumb.bind("connection", function (info, originalEvent) {	    
	    var id = info.connection.getParameter("id");	    
	    var same = (info.targetId==info.sourceId);
	    if (id == -1 && !same) {
	        createMessage(info);
	    } else {
	        if (!same) {	            
	            updateMessage(info);
	        } else {
	            $('#myModal').modal('toggle');
	            $('#myModal').modal('show');
	            jsPlumb.detach(info.connection);
	            //jsPlumb.deleteEndpoint(info.targetEndpoint);
	            //jsPlumb.deleteEndpoint(info.sourceEndpoint);
	        }
	    }  
	});
	

	jsPlumb.bind("connectionDetached", function (info, originalEvent) {
	    removeMessage(info.connection.getParameter("id"));
	});

    /*------------------- NOT WORKING ----------------------------- 
	jsPlumb.bind("connectionMoved", function (info, originalEvent) {
	    updateMessage(info);
	});*/

	

	$('#pdesignercontainer').dblclick(function (e) {
	    if (Edit == 1) {
	        var container = $('#pdesignercontainer');
	        var x = container.offset().left;
	        var y = container.offset().top;

	        x = Math.round(e.pageX - x);
	        y = Math.round(e.pageY - y);
	        var info = createSubject(x - x % 20, y - y % 20);
	        addSubject('#pdesignercontainer', info)
	    } 
	});
	

	
	function addMessage(messageinfo) {
	    var oldMode = false;
	    var messages = getFromAPI(apiURL + processId + "/Messages");
	    $.each(messages, function (i, item) { if (item.EndPoints == null) oldMode = true; });
	    var c;
	    if (oldMode) { //both null
	        var e1 = jsPlumb.addEndpoint("pdesignersubject" + messageinfo.From, sourceMessageOption);
	        e1.setEnabled(EnableDrag);
	        var e2 = jsPlumb.addEndpoint("pdesignersubject" + messageinfo.To, targetOption);
	        e2.setEnabled(EnableDrag);

	        c = jsPlumb.connect({
	            source: e1,
	            target: e2,
	            parameters: { "id": messageinfo.Id },
	            anchor: "Bottom",
	            deleteEndpointsOnDetach: EnableDrag
	        });
	    }else{
	        c = jsPlumb.connect({
	            source: "pdesignersubject" + messageinfo.From,
	            target: "pdesignersubject" + messageinfo.To,
	            parameters: { "id": messageinfo.Id },
	            anchors: [[messageinfo.EndPoints[0], messageinfo.EndPoints[1], 0, 0], [messageinfo.EndPoints[2], messageinfo.EndPoints[3], 0, 0]],
	            paintStyle: { lineWidth: 3, strokeStyle: "#0070c0", fillStyle: "transparent", radius: 6, },
	            endpointStyle: { fillStyle: "transparent" },
	            //endpointStyle: { fillStyle: "transparent", outlineColor: "black", outlineWidth: 6 },
	            //endpoints: [["Dot", { radius: 5 }], ["Dot", { radius: 5 }]],
	            overlays: [["Label", { label: "Message", cssClass: "pdesignermessageLabel", id: "label" }],
                              ["Arrow", { location: 1, length: 20, width: 15, id: 'arrow', foldback: 0.9 }]],
	            deleteEndpointsOnDetach: EnableDrag
	        });
	    }
	    c.getOverlay("label").setLabel(messageinfo.TypeName);

	    jsPlumb.bind('click', function (c, e) {
	        var mid = c.getParameter("id");
	        updateConfigPanel("_EditMessage", { "processid": processId, "messageid": mid });
	    });	    
	    
	}
    
	function addSubject(container, subjectinfo) {
		var newSubject;

		newSubject = $('<div>').attr({ 'id': 'pdesignersubject' + subjectinfo.Id, 'title': subjectinfo.Name }).addClass('pdesignersubject');
		if (subjectinfo.MultiSubject) {
		    newSubject.append('<span class="glyphicon glyphicon-pause"></span>')
		}
		if (subjectinfo.ExternalSubject) {
		    newSubject.addClass('pdesignerexternal');
		    newSubject.append('<span class="glyphicon glyphicon-cloud"></span>')

		}
		else {
			newSubject.addClass('pdesignerinternal');
		}

		if (subjectinfo.CanBeStarted) {		   
		    newSubject.append('<span class="glyphicon glyphicon-play"></span>')
		}

		var title = $('<div>').addClass('pdesignertitle').text(subjectinfo.Name);
        /*
		newSubject.css({
			'top': subjectinfo.PositionTop,
			'left': subjectinfo.PositionLeft
		});*/
		if (subjectinfo.PositionTop != 0) {
		    newSubject.css({
		        'top': subjectinfo.PositionTop,
		        'left': subjectinfo.PositionLeft
		    });
		} else {
		    subjectinfo.PositionTop += (Math.random() * 600);
		    subjectinfo.PositionLeft += (Math.random() * 500);
		    newSubject.css({
		        'top': subjectinfo.PositionTop,
		        'left': subjectinfo.PositionLeft
		    });
		    subjectMoved(newSubject.attr("id").replace("pdesignersubject", ""), newSubject.css("left"), newSubject.css("top"));
		}

		newSubject.append(title);

		var oldMode = false;
		var messages = getFromAPI(apiURL + processId + "/Messages");
		$.each(messages, function (i, item) { if (item.EndPoints == null) oldMode = true; });
		if (EnableDrag) {//white box on the subject
		    if (oldMode) {
		        //first box type
		        jsPlumb.makeTarget(newSubject, targetOption);

		        var message = $('<div>').attr('id', 'pdesignermessage' + subjectinfo.Id).addClass('pdesignermessage');
		        jsPlumb.makeSource(message, { parent: newSubject }, sourceMessageOption);

		        newSubject.append(message);
		    }
             
            
            /* //second box type
		    var message = $('<div>').attr('onclick', "pointsShow();").addClass('pdesignermessage');
		    newSubject.append(message); */

		    jsPlumb.draggable(newSubject, {
		        containment: 'parent'
            , grid: [20, 20]
		    });
		}
		

		newSubject.dblclick(function (e) {
		    /*var data = {
		        CanvasWidth: 680,
		        CanvasHeight: 900
		    }
		    postFromAPI(apiURL + processId + "/subjects/" + subjectId + "/States", data);*/
		    e.stopPropagation();
		    var subjectid = $(this).attr("id").replace("pdesignersubject", "");
		    window.location = URL+"Pdesigner/Viewsubject?processid=" + processId + "&subjectid=" + subjectid + "&edit=" + Edit;
		    
		});

		newSubject.click(function (e) {		   
		        var subjectid = $(this).attr("id").replace("pdesignersubject", "");
		        updateConfigPanel("_EditSubject", { "processid": processId, "subjectid": subjectid, "edit": Edit });		    
		})

		$(container).append(newSubject);

		newSubject.mouseup(function () {
			var self = $(this);
			subjectMoved(self.attr("id").replace("pdesignersubject", ""), self.css("left"), self.css("top"));
		});
		
		if (EnableDrag && !oldMode) {
		    for (var i in dynamicAnchors) {
		        jsPlumb.addEndpoint("pdesignersubject" + subjectinfo.Id, {
		            isTarget: true, isSource: true, anchor: dynamicAnchors[i], connectorStyle: connectorMessageStyle,
		            connectorOverlays: [["Arrow", { location: 1 }],
                        ["Label", { label: "Message", cssClass: "pdesignermessageLabel", id: "label" }]],
		            paintStyle: {
		                strokeStyle: "#FFCC00FF", //"#FFCC00FF" for invisible dots
		                fillStyle: "transparent",
		                radius: 6,
		                lineWidth: 3
		            },
		            endpoint: ["Rectangle", {
		                width: 35,
		                height: 15
		            }],
		            connector: ["StateMachine", { curviness: 10 }],
		            maxConnections: 0,
		            parameters: { "id": -1 },
		        });
		    }
		}
	    /*  
		jsPlumb.addEndpoint("pdesignersubject" + subjectinfo.Id, { isTarget: true, anchor: [0.2, 1, 0, 1] });*/
		//if (pointsShowing) { pointsShowing = !pointsShowing; pointsShow();}
	}
	

	function createSubject(x, y) {
		var data = {
			PositionTop: y,
			PositionLeft: x
		}
		var result = postFromAPI(apiURL +  processId + "/subjects", data);
		$("#pdesignerlog").append("<li>created subject: " + result.Id + "</li>");
		updateConfigPanel("_EditSubject", { "processid": processId, "subjectid": result.Id });
		return result;
	}
    
	//Events:
	function subjectMoved(id, x, y) {
		var data = {
			Id: id,
			PositionTop: Math.round(y.replace("px", "")),
			    PositionLeft: Math.round(x.replace("px", ""))
		}
		putFromAPI(apiURL +  processId + "/Subjects/" + id, data)
		$("#pdesignerlog").append("<li>moved subject: " + id + " to (" + data.PositionLeft + "," + data.PositionTop + ")</li>");

		
	}


	function createMessage(info) {

	    var data = {
	        From: info.sourceId.replace("pdesignersubject", ""),
	        To: info.targetId.replace("pdesignersubject", ""),
	        Endpoints: [info.connection.endpoints[0].anchor.x, info.connection.endpoints[0].anchor.y, info.connection.endpoints[1].anchor.x, info.connection.endpoints[1].anchor.y]
	        //Endpoints: [info.sourceEndpoint, info.targetEndpoint]
	    }

		var result = postFromAPI(apiURL + processId + "/Messages", data);
		info.connection.setParameter("id", result.Id);
		$("#pdesignerlog").append("<li>created message: " + result.Id + "</li>");
		updateConfigPanel("_EditMessage", { "processid": processId, "messageid": result.Id });

		jsPlumb.bind('click', function (c, e) {
		    var mid = c.getParameter("id");
		    updateConfigPanel("_EditMessage", { "processid": processId, "messageid": mid });
		});
	    /*} else {
	        jsPlumb.detach(info.connection);
	        $('#myModal').modal('toggle');
	        $('#myModal').modal('show');
	        window.alert("error");
	        
	    }*/
	}

	function removeMessage(id) {
		deleteFromAPI(apiURL +  processId + "/Messages/" + id);
		$("#pdesignerlog").append("<li>deleted message: " + id + "</li>");
		clearConfigPanel();
	}

	function updateMessage(info) {
		var data = {
			Id: info.connection.getParameter("id"),
			From: info.sourceId.replace("pdesignersubject", ""),
			To: info.targetId.replace("pdesignersubject", ""),
		}

		putFromAPI(apiURL +  processId + "/Messages/" + data.Id, data)
		$("#pdesignerlog").append("<li>Message " + data.Id + " moved:  (s: " + data.Source + " ,t: " + data.Target + ")</li>");
	}
	$('#pdesignercontainer').mouseup(function (e) {
	    var self = $(this);
	    canvasResized($('#pdesignercontainer').width(), $('#pdesignercontainer').height());
	});
	function canvasResized(x, y) {
	    var data = {
	        CanvasWidth: x,
	        CanvasHeight: y
	    }
	    putFromAPI(apiURL + processId + "/Canvas", data)
	}


});

function deleteSubject(id) {
 
    var eps = jsPlumb.getEndpoints('pdesignersubject' + id);
    for (var j = 0; j < eps.length; j++) {
        jsPlumb.deleteEndpoint(eps[j]);
    }
    var item = $('#pdesignersubject' + id)
    jsPlumb.detachAllConnections(item);
    item.remove();

    $("#pdesignerlog").append("<li>delete subject: " + id + "</li>");
    deleteFromAPI(apiURL + processId + "/Subjects/" + id);

    clearConfigPanel();
}


function resetProcess() {
    //if (pointsShowing) pointsShow();
    var subjects = getFromAPI(apiURL + processId + "/Subjects");

    $.each(subjects, function (i, item) {
        deleteSubject(item.Id);
    });
    
    var messages = getFromAPI(apiURL + processId + "/Messages");

    $.each(messages, function (i, item) {
        removeMessage(item.Id);
    });
    
    clearConfigPanel();
}


function imprt(name, id, pleft, ptop, pid) {

    var did = 'pdesignersubject' + id;
    var left = pleft + "px;";
    var top = ptop + "px;";
    var container = $('#pdesignercontainer');
    $(container).append("<div style='top:" + top + "left:" + left + "'class='pdesignersubject pdesignerinternal ui-droppable ui-draggable _jsPlumb_endpoint_anchor_' title='" + name + "' id=" + did + "><div class='pdesignertitle'>" + name + "</div></div>");
    var oldMode = false;
    var messages = getFromAPI(apiURL + processId + "/Messages");
    $.each(messages, function (i, item) { if (item.EndPoints == null) oldMode = true; });
    if (oldMode) {   //white box
        jsPlumb.makeTarget(did, {
            isTarget: true,
            anchor: 'Continuous',
            paintStyle: { fillStyle: "transparent", strokeStyle: "#000000", radius: 6, lineWidth: 3 }
        });
        var message = $('<div>').attr('id', 'pdesignermessage' + did).addClass('pdesignermessage');

        jsPlumb.makeSource(message, { parent: did }, {
            isSource: true,
            anchor: 'Continuous',
            connectorStyle: { lineWidth: 3, strokeStyle: "#0070c0" },
            connectorOverlays: [["Arrow", { location: 1 }],
                ["Label", { label: "Message", cssClass: "pdesignermessageLabel", id: "label" }]],
            paintStyle: { fillStyle: "transparent", strokeStyle: "#000000", radius: 6, lineWidth: 3 },
            connector: ["StateMachine", { curviness: 10 }],
            parameters: { "id": -1 }
        });
    }
    did = '#' + did;
    if(oldMode) $(did).append(message);
    
    $(did).draggable({
        containment: 'parent',
        //drag: function (e) { $(this).find('._jsPlumb_endpoint_anchor_').each(function (i, e) { jsPlumb.repaint($(e).parent()); }) }
        drag: function (e) {jsPlumb.repaintEverything();}
    });
    $(did).click(function (e) {
        var subjectid = $(this).attr("id").replace("pdesignersubject", "");
        updateConfigPanel("_EditSubject", { "processid": processId, "subjectid": subjectid, "edit": Edit });
    })
    $(did).dblclick(function (e) {
        e.stopPropagation();
        var subjectid = $(this).attr("id").replace("pdesignersubject", "");
        window.location = URL + "Pdesigner/Viewsubject?processid=" + processId + "&subjectid=" + subjectid + "&edit=" + 1;
    });
    $(did).mouseup(function () {
        var self = $(this);
        var data = {
            Id: id,
            PositionTop: Math.round(self.css("top").replace("px", "")),
            PositionLeft: Math.round(self.css("left").replace("px", ""))
        }
        putFromAPI(apiURL + pid + "/Subjects/" + id, data)
    });
    var dynamicAnchors = [[0.2, 1, 0, 1], [0.5, 1, 0, 1], [0.8, 1, 0, 1],
                       [0.2, 0, 0, 1], [0.5, 0, 0, 1], [0.8, 0, 0, 1],
//                           [0, 0.1, 0, 1], [0, 0.2, 0, 1], [0, 0.3, 0, 1], [0, 0.4, 0, 1], [0, 0.5, 0, 1], [0, 0.6, 0, 1], [0, 0.7, 0, 1], [0, 0.8, 0, 1], [0, 0.9, 0, 1],
                         [0, 0.1, 0, 1], [0, 0.15, 0, 1], [0, 0.2, 0, 1], [0, 0.25, 0, 1], [0, 0.3, 0, 1], [0, 0.35, 0, 1], [0, 0.4, 0, 1], [0, 0.45, 0, 1], [0, 0.5, 0, 1], [0, 0.55, 0, 1], [0, 0.6, 0, 1], [0, 0.65, 0, 1], [0, 0.7, 0, 1], [0, 0.75, 0, 1], [0, 0.8, 0, 1], [0, 0.85, 0, 1], [0, 0.9, 0, 1],
                          [1, 0.1, 0, 1], [1, 0.15, 0, 1], [1, 0.2, 0, 1], [1, 0.25, 0, 1], [1, 0.3, 0, 1], [1, 0.35, 0, 1], [1, 0.4, 0, 1], [1, 0.45, 0, 1], [1, 0.5, 0, 1], [1, 0.55, 0, 1], [1, 0.6, 0, 1], [1, 0.65, 0, 1], [1, 0.7, 0, 1], [1, 0.75, 0, 1], [1, 0.8, 0, 1], [1, 0.85, 0, 1], [1, 0.9, 0, 1]
    ];
    var connectorMessageStyle = {
        lineWidth: 3,
        strokeStyle: "#0070c0"
    };
    if (!oldMode) {
        for (var i in dynamicAnchors) {
            jsPlumb.addEndpoint('pdesignersubject' + id, {
                isTarget: true, isSource: true, anchor: dynamicAnchors[i], connectorStyle: connectorMessageStyle,
                connectorOverlays: [["Arrow", { location: 1 }],
                    ["Label", { label: "Message", cssClass: "pdesignermessageLabel", id: "label" }]],
                paintStyle: {
                    strokeStyle: "#FFCC00FF",
                    fillStyle: "transparent",
                    radius: 6,
                    lineWidth: 3
                },
                endpoint: ["Rectangle", {
                    width: 35,
                    height: 15
                }],
                connector: ["StateMachine", { curviness: 10 }],
                maxConnections: 0,
                parameters: { "id": -1 },
            });
        }
    }
}

var pointsShowing = false;
function pointsShow() {    
    var subjects = getFromAPI(apiURL + processId + "/Subjects");   
    
    $.each(subjects, function (i, item) {
        var actual = 'pdesignersubject' + item.Id;        
        var eps = jsPlumb.getEndpoints(actual);
        for (var j = 0; j < eps.length; j++) {
            if (!pointsShowing) eps[j].setPaintStyle({ strokeStyle: '#FFCC00', fillStyle: "transparent", radius: 6, lineWidth: 3 });
            //else eps[j].setPaintStyle({ strokeStyle: '#FFFFFFFF', fillStyle: "transparent", radius: -10, lineWidth: -10 });          
            else eps[j].setPaintStyle({ strokeStyle: '#FFCC00F0', fillStyle: "transparent", radius: 6, lineWidth: 3 });
        }
    });
    pointsShowing = !pointsShowing;
}

$('.window').resizable();
$('#pdesignerconfig').draggable();


