function notifyMe(title, message, icon) {
	
	function init(callback){
		if(window.webkitNotifications){
			if(webkitNotifications.checkPermission() != 0){
				var permissionDiv = document.createElement("div");
				permissionDiv.className = "xNotification-permission";
				permissionDiv.innerHTML = "<H1>This site wants use desktop notifications. Please click on this bar to bring up the permission dialog.";
				document.getElementsByTagName("body")[0].appendChild(permissionDiv);
				permissionDiv.onclick = function(){
					document.getElementsByTagName("body")[0].removeChild(permissionDiv);
					webkitNotifications.requestPermission(function(){
						if(webkitNotifications.checkPermission() == 0){
							callback();
						} else {
							console.log("Not Allowed.");
						}
					});
				}
			} else {
				callback();
			}
		} else if(window.Notification){
			Notification.requestPermission(function(permission){
				if(permission == 'granted'){
					callback();
				} else {
					console.log("Not Allowed.");
				}
			});
		}
	}
	
	init(function(){
		if(window.webkitNotifications){
			n = webkitNotifications.createNotification(icon, title, message);
			n.show();
		} else if(window.Notification){
			var notification = new Notification(title, { icon: icon, body: message });
		}
	});
	
	
};
//notifyMe("ss","ssssss","8.png");


 