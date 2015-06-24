<!DOCTYPE html>
<html><head>
    <title>PlayFab API Documentation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="chrome=1,IE=edge">
    <meta name="viewport" content="user-scalable=yes, width=1024">
    <!-- Custom Fonts -->
    <link href="README_files/webfonts.css" rel="stylesheet">
    <link href="README_files/MuseoSans.css" rel="stylesheet">
    <link href="README_files/css_002.css" rel="stylesheet" type="text/css">
    <link href="README_files/css.css" rel="stylesheet" type="text/css">

    <!-- CSS Files -->
    
    <link rel="stylesheet" type="text/css" href="README_files/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="README_files/bootstrap-theme.css">
    <link rel="stylesheet" type="text/css" href="README_files/api-new.css">
    <link rel="stylesheet" type="text/css" href="README_files/APIdocs.css">
    <script>
        var signinOpen = false;
    </script>
<script src="README_files/HYPE.js" type="text/javascript"></script><div>&nbsp;<style id="" type="text/css">.HYPE_element{-webkit-transform:rotateY(0);}video.HYPE_element{-webkit-transform:none;}.HYPE_scene {color:#000;font-size:16px;font-weight:normal;font-family:Helvetica,Arial,Sans-Serif;font-weight:normal;font-style:normal;font-variant:normal;text-decoration:none;text-align:left;text-transform:none;text-indent:0;text-shadow:none;line-height:normal;letter-spacing:normal;white-space:normal;word-spacing:normal;vertical-align:baseline;border:none;background-color:transparent;background-image:none;-webkit-font-smoothing:antialiased;-moz-backface-visibility:hidden;}.HYPE_scene div,.HYPE_scene span,.HYPE_scene applet,.HYPE_scene object,.HYPE_scene iframe,.HYPE_scene h1,.HYPE_scene h2,.HYPE_scene h3,.HYPE_scene h4,.HYPE_scene h5,.HYPE_scene h6,.HYPE_scene p,.HYPE_scene blockquote,.HYPE_scene pre,.HYPE_scene a,.HYPE_scene abbr,.HYPE_scene acronym,.HYPE_scene address,.HYPE_scene big,.HYPE_scene cite,.HYPE_scene code,.HYPE_scene del,.HYPE_scene dfn,.HYPE_scene em,.HYPE_scene img,.HYPE_scene ins,.HYPE_scene kbd,.HYPE_scene q,.HYPE_scene s,.HYPE_scene samp,.HYPE_scene small,.HYPE_scene strike,.HYPE_scene strong,.HYPE_scene sub,.HYPE_scene sup,.HYPE_scene tt,.HYPE_scene var,.HYPE_scene b,.HYPE_scene u,.HYPE_scene i,.HYPE_scene center,.HYPE_scene dl,.HYPE_scene dt,.HYPE_scene dd,.HYPE_scene ol,.HYPE_scene ul,.HYPE_scene li,.HYPE_scene fieldset,.HYPE_scene form,.HYPE_scene label,.HYPE_scene legend,.HYPE_scene table,.HYPE_scene caption,.HYPE_scene tbody,.HYPE_scene tfoot,.HYPE_scene thead,.HYPE_scene tr,.HYPE_scene th,.HYPE_scene td,.HYPE_scene article,.HYPE_scene aside,.HYPE_scene canvas,.HYPE_scene details,.HYPE_scene embed,.HYPE_scene figure,.HYPE_scene figcaption,.HYPE_scene footer,.HYPE_scene header,.HYPE_scene hgroup,.HYPE_scene menu,.HYPE_scene nav,.HYPE_scene output,.HYPE_scene ruby,.HYPE_scene section,.HYPE_scene summary,.HYPE_scene time,.HYPE_scene mark,.HYPE_scene audio,.HYPE_scene video{color:inherit;font-size:inherit;font-weight:inherit;font-family:inherit;font-weight:inherit;font-style:inherit;font-variant:inherit;text-decoration:inherit;text-align:inherit;text-transform:inherit;text-indent:inherit;text-shadow:inherit;line-height:inherit;letter-spacing:inherit;white-space:inherit;word-spacing:inherit;vertical-align:inherit;border:none;background-color:transparent;background-image:none;padding:0;}.HYPE_scene p{display:block;margin:1em 0;}.HYPE_scene div,.HYPE_scene layer{display:block;}.HYPE_scene article,.HYPE_scene aside,.HYPE_scene footer,.HYPE_scene header,.HYPE_scene hgroup,.HYPE_scene nav,.HYPE_scene section{display:block;}.HYPE_scene blockquote{display:block;margin:1em 40px;}.HYPE_scene figcaption{display:block;}.HYPE_scene figure{display:block;margin:1em 40px;}.HYPE_scene q{display:inline;}.HYPE_scene q:before{content:open-quote;}.HYPE_scene q:after{content:close-quote;}.HYPE_scene center{display:block;text-align:center;}.HYPE_scene hr{display:block;margin:.5em auto;border-style:inset;border-width:1px;}.HYPE_scene h1,.HYPE_scene h2,.HYPE_scene h3,.HYPE_scene h4,.HYPE_scene h5,.HYPE_scene h6{display:block;margin-left:0;margin-right:0;font-weight:bold;}.HYPE_scene h1{font-size:2em;margin-top:.67em;margin-bottom:.67em;}.HYPE_scene h2{font-size:1.5em;margin-top:.83em;margin-bottom:.83em;}.HYPE_scene h3{font-size:1.17em;margin-top:1em;margin-bottom:1em;}.HYPE_scene h4{margin-top:1.33em;margin-bottom:1.33em;}.HYPE_scene h5{font-size:.83em;margin-top:1.67em;margin-bottom:1.67em;}.HYPE_scene h6{font-size:.67em;margin-top:2.33em;margin-bottom:2.33em;}.HYPE_scene table{display:table;border-collapse:separate;border-spacing:2px;border-color:gray;}.HYPE_scene thead{display:table-header-group;vertical-align:middle;border-color:inherit;}.HYPE_scene tbody{display:table-row-group;vertical-align:middle;border-color:inherit;}.HYPE_scene tfoot{display:table-footer-group;vertical-align:middle;border-color:inherit;}.HYPE_scene col{display:table-column;}.HYPE_scene colgroup{display:table-column-group;}.HYPE_scene tr{display:table-row;vertical-align:inherit;border-color:inherit;}.HYPE_scene td,.HYPE_scene th{display:table-cell;vertical-align:inherit;}.HYPE_scene th{font-weight:bold;}.HYPE_scene caption{display:table-caption;text-align:center;}.HYPE_scene ul,.HYPE_scene menu,.HYPE_scene dir{display:block;list-style-type:disc;margin:1em 0;padding-left:40px;}.HYPE_scene ol{display:block;list-style-type:decimal;margin:1em 0;padding-left:40px;}.HYPE_scene li{display:list-item;margin:0;}.HYPE_scene ul ul,.HYPE_scene ol ul{list-style-type:circle;}.HYPE_scene ol ol ul,.HYPE_scene ol ul ul,.HYPE_scene ul ol ul,.HYPE_scene ul ul ul{list-style-type:square;}.HYPE_scene dd{display:block;margin-left:40px;}.HYPE_scene dl{display:block;margin:1em 0;}.HYPE_scene dt{display:block;}.HYPE_scene ol ul,.HYPE_scene ul ol,.HYPE_scene ul ul,.HYPE_scene ol ol{margin-top:0;margin-bottom:0;}.HYPE_scene u,.HYPE_scene ins{text-decoration:underline;}.HYPE_scene strong,.HYPE_scene b{font-weight:bolder;}.HYPE_scene i,.HYPE_scene cite,.HYPE_scene em,.HYPE_scene var,.HYPE_scene address{font-style:italic;}.HYPE_scene tt,.HYPE_scene code,.HYPE_scene kbd,.HYPE_scene samp{font-family:monospace;}.HYPE_scene pre,.HYPE_scene xmp,.HYPE_scene plaintext,.HYPE_scene listing{display:block;font-family:monospace;white-space:pre;margin:1em 0;}.HYPE_scene mark{background-color:yellow;color:black;}.HYPE_scene big{font-size:larger;}.HYPE_scene small{font-size:smaller;}.HYPE_scene s,.HYPE_scene strike,.HYPE_scene del{text-decoration:line-through;}.HYPE_scene sub{vertical-align:sub;font-size:smaller;}.HYPE_scene sup{vertical-align:super;font-size:smaller;}.HYPE_scene nobr{white-space:nowrap;}.HYPE_scene a{color:blue;text-decoration:underline;cursor:pointer;}.HYPE_scene a:active{color:red;}.HYPE_scene noframes{display:none;}.HYPE_scene frameset,.HYPE_scene frame{display:block;}.HYPE_scene frameset{border-color:inherit;}.HYPE_scene iframe{border:0;}.HYPE_scene details{display:block;}.HYPE_scene summary{display:block;}</style>&nbsp;</div><div><link href="README_files/css_002.css" rel="stylesheet" type="text/css"></div><div><link href="README_files/css.css" rel="stylesheet" type="text/css"></div><script>try {  for(var lastpass_iter=0; lastpass_iter < document.forms.length; lastpass_iter++){    var lastpass_f = document.forms[lastpass_iter];    if(typeof(lastpass_f.lpsubmitorig)=="undefined"){      if (typeof(lastpass_f.submit) == "function") {        lastpass_f.lpsubmitorig = lastpass_f.submit;        lastpass_f.submit = function(){          var form = this;          try {            if (document.documentElement && 'createEvent' in document)            {              var forms = document.getElementsByTagName('form');              for (var i=0 ; i<forms.length ; ++i)                if (forms[i]==form)                {                  var element = document.createElement('lpformsubmitdataelement');                  element.setAttribute('formnum',i);                  element.setAttribute('from','submithook');                  document.documentElement.appendChild(element);                  var evt = document.createEvent('Events');                  evt.initEvent('lpformsubmit',true,false);                  element.dispatchEvent(evt);                  break;                }            }          } catch (e) {}          try {            form.lpsubmitorig();          } catch (e) {}        }      }    }  }} catch (e) {}</script></head>
<body>

    <!--Start Header-->
    <div class="mainHeader">

        <div class="logoPosition">
            <a href="https://playfab.com/"><img src="README_files/PlayFabLogo2x.png" width="151"></a>
        </div><!--End Logo Div-->

        <div class="mainMenu">
            <a href="https://playfab.com/features">Features</a>
            <a href="https://playfab.com/gamemanager"><span>Game Manager</span></a>
            <a href="https://playfab.com/developer-resources">Develop</a>
            <a href="https://playfab.com/customers">Customers</a>
            <a href="https://playfab.com/pricing">Pricing</a>
            <a href="https://playfab.com/blog">Blog</a>
            <a href="https://support.playfab.com/support/home">Help</a>
        </div><!--End Menu Div-->

    </div><!--End Header Div-->

    <div class="signInDropdown">
        <div hyp_dn="signin" id="signin_hype_container" style="position: relative; overflow: hidden; width: 310px; height: 265px;">
            <script type="text/javascript" charset="utf-8" src="README_files/signin_hype_generated_script.js"></script>
        <div hyp_b="0" hyp_a="0" style="display: block; overflow: hidden; position: absolute; top: 0px; left: 0px; z-index: 1; opacity: 1; width: 100%; height: 100%;" hype_scene_index="0" id="hype-scene-YOg27ukRLARsTVk5" class="HYPE_scene"><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 1;" class="HYPE_element_container"><div hyp_w="0px" hyp_y="#000000" hyp_z="0px" hyp_x="0px" hyp_an="23px" hyp_am="110px" hyp_b="81px" hyp_a="4px" hyp_ar="36" style="pointer-events: auto; position: absolute; border-style: none; z-index: 1; border-width: 0px; -moz-user-select: none; padding: 6px; background-color: rgb(248, 107, 0); border-radius: 5px; border-color: rgb(219, 219, 219); line-height: 22px; word-wrap: break-word; display: inline; font-family: &quot;Merriweather Sans&quot;; font-size: 16px; text-align: center; font-weight: 700; color: rgb(255, 255, 255); cursor: pointer; overflow: visible; text-shadow: none; width: 110px; height: 23px; top: 4px; left: 81px;" id="hype-obj-afGEsmLlSqCE7rw8" class="HYPE_element">Sign In</div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 2;" class="HYPE_element_container"><div hyp_an="192px" hyp_am="197px" hyp_b="356px" hyp_a="39px" hyp_ar="36" style="pointer-events: auto; position: absolute; overflow: visible; z-index: 2; opacity: 0; width: 197px; height: 192px; top: 39px; left: 356px;" id="hype-obj-cVkhVQkhnJBeoXO7" class="HYPE_element"><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 1;" class="HYPE_element_container"><div hyp_t="0px" hyp_u="#7E7E7E" hyp_v="0px" hyp_s="0px" hyp_an="190px" hyp_am="195px" hyp_b="0px" hyp_a="0px" hyp_ar="36" style="pointer-events: auto; position: absolute; border-radius: 5px; border-style: solid; background-color: rgb(242, 242, 242); border-width: 1px; border-color: rgb(217, 217, 217); overflow: visible; z-index: 1; width: 195px; height: 190px; top: 0px; left: 0px;" id="hype-obj-3P7pVZTRFJdLO8Q9" class="HYPE_element"></div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 3;" class="HYPE_element_container"><div hyp_an="15px" hyp_am="153px" hyp_b="7px" hyp_a="159px" hyp_ar="36" style="pointer-events: auto; position: absolute; z-index: 3; border-style: none; border-width: 0px; -moz-user-select: none; padding: 6px; border-color: rgb(160, 160, 160); word-wrap: break-word; display: inline; font-family: &quot;Merriweather Sans&quot;; font-size: 12px; text-align: left; font-weight: 300; color: rgb(0, 173, 239); cursor: pointer; overflow: visible; width: 153px; height: 15px; top: 159px; left: 7px;" id="hype-obj-TwHncC0eajV3kDBL" class="HYPE_element">Forgot password?</div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 2;" class="HYPE_element_container"><div hyp_an="163px" hyp_am="166px" hyp_b="9px" hyp_a="6px" hyp_ar="36" style="pointer-events: auto; position: absolute; overflow: visible; z-index: 2; display: none; width: 166px; height: 163px; top: 6px; left: 9px;" id="hype-obj-fQiJLRKByy28hxc4" class="HYPE_element"><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 1;" class="HYPE_element_container"><div hyp_an="33px" hyp_am="159px" hyp_b="7px" hyp_a="28px" hyp_ar="36" style="pointer-events: auto; position: absolute; border-style: none; border-width: 0px; border-color: rgb(160, 160, 160); overflow: visible; z-index: 1; width: 159px; height: 33px; top: 28px; left: 7px;" id="emailField" class="HYPE_element"><input style="background-image: url(&quot;data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAASCAYAAABSO15qAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH3QsPDhss3LcOZQAAAU5JREFUOMvdkzFLA0EQhd/bO7iIYmklaCUopLAQA6KNaawt9BeIgnUwLHPJRchfEBR7CyGWgiDY2SlIQBT/gDaCoGDudiy8SLwkBiwz1c7y+GZ25i0wnFEqlSZFZKGdi8iiiOR7aU32QkR2c7ncPcljAARAkgckb8IwrGf1fg/oJ8lRAHkR2VDVmOQ8AKjqY1bMHgCGYXhFchnAg6omJGcBXEZRtNoXYK2dMsaMt1qtD9/3p40x5yS9tHICYF1Vn0mOxXH8Uq/Xb389wff9PQDbQRB0t/QNOiPZ1h4B2MoO0fxnYz8dOOcOVbWhqq8kJzzPa3RAXZIkawCenHMjJN/+GiIqlcoFgKKq3pEMAMwAuCa5VK1W3SAfbAIopum+cy5KzwXn3M5AI6XVYlVt1mq1U8/zTlS1CeC9j2+6o1wuz1lrVzpWXLDWTg3pz/0CQnd2Jos49xUAAAAASUVORK5CYII=&quot;); background-repeat: no-repeat; background-attachment: scroll; background-position: right center;" id="UserEmail" class="emailField" type="email"></div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 2;" class="HYPE_element_container"><div hyp_an="33px" hyp_am="159px" hyp_b="7px" hyp_a="96px" style="pointer-events: auto; position: absolute; border-style: none; border-width: 0px; border-color: rgb(160, 160, 160); overflow: visible; z-index: 2; width: 159px; height: 33px; top: 96px; left: 7px;" id="passwordField" class="HYPE_element"><input style="background-image: url(&quot;data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAASCAYAAABSO15qAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH3QsPDhss3LcOZQAAAU5JREFUOMvdkzFLA0EQhd/bO7iIYmklaCUopLAQA6KNaawt9BeIgnUwLHPJRchfEBR7CyGWgiDY2SlIQBT/gDaCoGDudiy8SLwkBiwz1c7y+GZ25i0wnFEqlSZFZKGdi8iiiOR7aU32QkR2c7ncPcljAARAkgckb8IwrGf1fg/oJ8lRAHkR2VDVmOQ8AKjqY1bMHgCGYXhFchnAg6omJGcBXEZRtNoXYK2dMsaMt1qtD9/3p40x5yS9tHICYF1Vn0mOxXH8Uq/Xb389wff9PQDbQRB0t/QNOiPZ1h4B2MoO0fxnYz8dOOcOVbWhqq8kJzzPa3RAXZIkawCenHMjJN/+GiIqlcoFgKKq3pEMAMwAuCa5VK1W3SAfbAIopum+cy5KzwXn3M5AI6XVYlVt1mq1U8/zTlS1CeC9j2+6o1wuz1lrVzpWXLDWTg3pz/0CQnd2Jos49xUAAAAASUVORK5CYII=&quot;); background-repeat: no-repeat; background-attachment: scroll; background-position: right center;" id="Password" class="passwordField" type="password">
</div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 3;" class="HYPE_element_container"><div hyp_an="11px" hyp_am="150px" hyp_b="0px" hyp_a="0px" style="pointer-events: auto; position: absolute; padding: 8px; color: rgb(77, 77, 77); display: inline; font-family: &quot;Merriweather Sans&quot;; font-size: 14px; word-wrap: break-word; font-weight: 300; overflow: visible; z-index: 3; width: 150px; height: 11px; top: 0px; left: 0px;" id="hype-obj-EWJFQfd3QMGyhKgb" class="HYPE_element">Email</div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 4;" class="HYPE_element_container"><div hyp_an="11px" hyp_am="150px" hyp_b="0px" hyp_a="68px" style="pointer-events: auto; position: absolute; padding: 8px; color: rgb(77, 77, 77); display: inline; font-family: &quot;Merriweather Sans&quot;; font-size: 14px; word-wrap: break-word; font-weight: 300; overflow: visible; z-index: 4; width: 150px; height: 11px; top: 68px; left: 0px;" id="hype-obj-o5SSWIrLs4ycboZk" class="HYPE_element">Password</div></div></div></div><div style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; pointer-events: none; z-index: 4;" class="HYPE_element_container"><div hyp_an="126px" hyp_am="171px" hyp_b="13px" hyp_a="15px" hyp_ar="36" style="pointer-events: auto; position: absolute; border-style: none; border-width: 0px; border-color: rgb(160, 160, 160); overflow: visible; z-index: 4; width: 171px; height: 126px; top: 15px; left: 13px;" id="hype-obj-JeV1XCxU79IHvvPK" class="HYPE_element"><form id="loginForm" style="font-family:'Merriweather Sans';font-size:14px;" action="https://developer.playfab.com/Account/Login" method="POST">
		
			<label for="UserEmail">Email</label><br>
			<input style="background-image: url(&quot;data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAASCAYAAABSO15qAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH3QsPDhss3LcOZQAAAU5JREFUOMvdkzFLA0EQhd/bO7iIYmklaCUopLAQA6KNaawt9BeIgnUwLHPJRchfEBR7CyGWgiDY2SlIQBT/gDaCoGDudiy8SLwkBiwz1c7y+GZ25i0wnFEqlSZFZKGdi8iiiOR7aU32QkR2c7ncPcljAARAkgckb8IwrGf1fg/oJ8lRAHkR2VDVmOQ8AKjqY1bMHgCGYXhFchnAg6omJGcBXEZRtNoXYK2dMsaMt1qtD9/3p40x5yS9tHICYF1Vn0mOxXH8Uq/Xb389wff9PQDbQRB0t/QNOiPZ1h4B2MoO0fxnYz8dOOcOVbWhqq8kJzzPa3RAXZIkawCenHMjJN/+GiIqlcoFgKKq3pEMAMwAuCa5VK1W3SAfbAIopum+cy5KzwXn3M5AI6XVYlVt1mq1U8/zTlS1CeC9j2+6o1wuz1lrVzpWXLDWTg3pz/0CQnd2Jos49xUAAAAASUVORK5CYII=&quot;); background-repeat: no-repeat; background-attachment: scroll; background-position: right center;" id="UserEmail" name="UserEmail" class="emailField" required="" minlength="3" type="text"><br><br>
			
			<label for="Password">Password</label><br>
			<input style="background-image: url(&quot;data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAASCAYAAABSO15qAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH3QsPDhss3LcOZQAAAU5JREFUOMvdkzFLA0EQhd/bO7iIYmklaCUopLAQA6KNaawt9BeIgnUwLHPJRchfEBR7CyGWgiDY2SlIQBT/gDaCoGDudiy8SLwkBiwz1c7y+GZ25i0wnFEqlSZFZKGdi8iiiOR7aU32QkR2c7ncPcljAARAkgckb8IwrGf1fg/oJ8lRAHkR2VDVmOQ8AKjqY1bMHgCGYXhFchnAg6omJGcBXEZRtNoXYK2dMsaMt1qtD9/3p40x5yS9tHICYF1Vn0mOxXH8Uq/Xb389wff9PQDbQRB0t/QNOiPZ1h4B2MoO0fxnYz8dOOcOVbWhqq8kJzzPa3RAXZIkawCenHMjJN/+GiIqlcoFgKKq3pEMAMwAuCa5VK1W3SAfbAIopum+cy5KzwXn3M5AI6XVYlVt1mq1U8/zTlS1CeC9j2+6o1wuz1lrVzpWXLDWTg3pz/0CQnd2Jos49xUAAAAASUVORK5CYII=&quot;); background-repeat: no-repeat; background-attachment: scroll; background-position: right center;" id="Password" name="Password" class="passwordField" required="" minlength="6" type="password"><br><br>
			
			<input id="External" name="External" value="true" type="hidden">
		
		</form></div></div></div></div></div></div>
    </div>
    <!--End Header-->

    <div class="container">
        <div class="header">
            <h3 class="text-muted">PlayFab API Documentation</h3>
        </div>
                <div class="breadcrumbs">
            <ol class="breadcrumb">
                <li><a href="https://api.playfab.com/Documentation">Services</a></li>
                <li>Client</li>
            </ol>
        </div>
<div class="class">
    <!-- GENERAL CLASS INFO -->
        <section class="summary well">
            APIs which provide the full range of PlayFab features 
available to the client - authentication, account and data management, 
inventory, friends, matchmaking, reporting, and platform-specific 
functionality
        </section>
    

    <!-- METHODS -->
        <section class="methods">
            <ul>
                        <li>
                            <span class="subsectionheading" id="Authentication">Authentication</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPhotonAuthenticationToken">GetPhotonAuthenticationToken</a>
                        </span>

                            <div class="summary">
                                Gets a Photon custom authentication 
token that can be used to securely join the player into a Photon room.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithAndroidDeviceID">LoginWithAndroidDeviceID</a>
                        </span>

                            <div class="summary">
                                Signs the user in using the Android device identifier, returning a session identifier that can
subsequently be used for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithEmailAddress">LoginWithEmailAddress</a>
                        </span>

                            <div class="summary">
                                Signs the user into the PlayFab account,
 returning a session identifier that can subsequently be used
for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithFacebook">LoginWithFacebook</a>
                        </span>

                            <div class="summary">
                                Signs the user in using a Facebook 
access token, returning a session identifier that can subsequently be 
used
for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithGoogleAccount">LoginWithGoogleAccount</a>
                        </span>

                            <div class="summary">
                                Signs the user in using a Google account
 access token, returning a session identifier that can subsequently be 
used
for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithIOSDeviceID">LoginWithIOSDeviceID</a>
                        </span>

                            <div class="summary">
                                Signs the user in using the 
vendor-specific iOS device identifier, returning a session identifier 
that can
subsequently be used for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithPlayFab">LoginWithPlayFab</a>
                        </span>

                            <div class="summary">
                                Signs the user into the PlayFab account,
 returning a session identifier that can subsequently be used
for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LoginWithSteam">LoginWithSteam</a>
                        </span>

                            <div class="summary">
                                Signs the user in using a Steam 
authentication ticket, returning a session identifier that can 
subsequently be used
for API calls which require an authenticated user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RegisterPlayFabUser">RegisterPlayFabUser</a>
                        </span>

                            <div class="summary">
                                Registers a new Playfab user account, returning a session identifier that can subsequently be
used for API calls which require an authenticated user
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Account Management">Account Management</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/AddUsernamePassword">AddUsernamePassword</a>
                        </span>

                            <div class="summary">
                                Adds playfab username/password auth to 
an existing semi-anonymous account created via a 3rd party auth method.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetAccountInfo">GetAccountInfo</a>
                        </span>

                            <div class="summary">
                                Retrieves the user's PlayFab account details
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPlayFabIDsFromFacebookIDs">GetPlayFabIDsFromFacebookIDs</a>
                        </span>

                            <div class="summary">
                                Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPlayFabIDsFromGameCenterIDs">GetPlayFabIDsFromGameCenterIDs</a>
                        </span>

                            <div class="summary">
                                Retrieves the unique PlayFab identifiers
 for the given set of Game Center identifiers (referenced in the Game 
Center Programming Guide as the Player Identifier).
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPlayFabIDsFromGoogleIDs">GetPlayFabIDsFromGoogleIDs</a>
                        </span>

                            <div class="summary">
                                Retrieves the unique PlayFab identifiers
 for the given set of Google identifiers. The Google identifiers are the
 IDs for the user accounts, available as "id" in the Google+ People API 
calls.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPlayFabIDsFromPSNAccountIDs">GetPlayFabIDsFromPSNAccountIDs</a>
                        </span>

                            <div class="summary">
                                Retrieves the unique PlayFab identifiers for the given set of PlayStation Network identifiers.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPlayFabIDsFromSteamIDs">GetPlayFabIDsFromSteamIDs</a>
                        </span>

                            <div class="summary">
                                Retrieves the unique PlayFab identifiers
 for the given set of Steam identifiers. The Steam identifiers 
are the profile IDs for the user accounts, available as SteamId in the 
Steamworks Community API calls.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserCombinedInfo">GetUserCombinedInfo</a>
                        </span>

                            <div class="summary">
                                Retrieves all requested data for a user 
in one unified request. By default, this API returns all 
data for the locally signed-in user. The input parameters may be used to
 limit the data retrieved any any subset of the
available data, as well as retrieve the available data for a different 
user. Note that certain data, including inventory,
virtual currency balances, and personally identifying information, may 
only be retrieved for the locally signed-in user.
In the example below, a request is made for the account details, virtual
 currency balances, and specified user data for
the locally signed-in user.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LinkAndroidDeviceID">LinkAndroidDeviceID</a>
                        </span>

                            <div class="summary">
                                Links the Android device identifier to the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LinkFacebookAccount">LinkFacebookAccount</a>
                        </span>

                            <div class="summary">
                                Links the Facebook account associated 
with the provided Facebook access token to the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LinkGameCenterAccount">LinkGameCenterAccount</a>
                        </span>

                            <div class="summary">
                                Links the Game Center account associated
 with the provided Game Center ID to the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LinkGoogleAccount">LinkGoogleAccount</a>
                        </span>

                            <div class="summary">
                                Links the currently signed-in user 
account to the Google account specified by the Google account access 
token
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LinkIOSDeviceID">LinkIOSDeviceID</a>
                        </span>

                            <div class="summary">
                                Links the vendor-specific iOS device identifier to the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LinkSteamAccount">LinkSteamAccount</a>
                        </span>

                            <div class="summary">
                                Links the Steam account associated with 
the provided Steam authentication ticket to the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/SendAccountRecoveryEmail">SendAccountRecoveryEmail</a>
                        </span>

                            <div class="summary">
                                Forces an email to be sent to the 
registered email address for the user's account, with a link allowing 
the user to change the password
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlinkAndroidDeviceID">UnlinkAndroidDeviceID</a>
                        </span>

                            <div class="summary">
                                Unlinks the related Android device identifier from the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlinkFacebookAccount">UnlinkFacebookAccount</a>
                        </span>

                            <div class="summary">
                                Unlinks the related Facebook account from the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlinkGameCenterAccount">UnlinkGameCenterAccount</a>
                        </span>

                            <div class="summary">
                                Unlinks the related Game Center account from the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlinkGoogleAccount">UnlinkGoogleAccount</a>
                        </span>

                            <div class="summary">
                                Unlinks the related Google account from the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlinkIOSDeviceID">UnlinkIOSDeviceID</a>
                        </span>

                            <div class="summary">
                                Unlinks the related iOS device identifier from the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlinkSteamAccount">UnlinkSteamAccount</a>
                        </span>

                            <div class="summary">
                                Unlinks the related Steam account from the user's PlayFab account
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UpdateUserTitleDisplayName">UpdateUserTitleDisplayName</a>
                        </span>

                            <div class="summary">
                                Updates the title specific display name for the user
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Player Data Management">Player Data Management</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetFriendLeaderboard">GetFriendLeaderboard</a>
                        </span>

                            <div class="summary">
                                Retrieves a list of ranked friends of 
the current player for the given statistic, starting from the indicated 
point in the leaderboard
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetLeaderboard">GetLeaderboard</a>
                        </span>

                            <div class="summary">
                                Retrieves a list of ranked users for the
 given statistic, starting from the indicated point in the leaderboard
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetLeaderboardAroundCurrentUser">GetLeaderboardAroundCurrentUser</a>
                        </span>

                            <div class="summary">
                                Retrieves a list of ranked users for the
 given statistic, centered on the currently signed-in user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserData">GetUserData</a>
                        </span>

                            <div class="summary">
                                Retrieves the title-specific custom data
 for the user which is readable and writable by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserPublisherData">GetUserPublisherData</a>
                        </span>

                            <div class="summary">
                                Retrieves the publisher-specific custom 
data for the user which is readable and writable by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserPublisherReadOnlyData">GetUserPublisherReadOnlyData</a>
                        </span>

                            <div class="summary">
                                Retrieves the publisher-specific custom data for the user which can only be read by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserReadOnlyData">GetUserReadOnlyData</a>
                        </span>

                            <div class="summary">
                                Retrieves the title-specific custom data for the user which can only be read by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserStatistics">GetUserStatistics</a>
                        </span>

                            <div class="summary">
                                Retrieves the details of all title-specific statistics for the user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UpdateUserData">UpdateUserData</a>
                        </span>

                            <div class="summary">
                                Creates and updates the title-specific 
custom data for the user which is readable and writable by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UpdateUserPublisherData">UpdateUserPublisherData</a>
                        </span>

                            <div class="summary">
                                Creates and updates the 
publisher-specific custom data for the user which is readable and 
writable by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UpdateUserStatistics">UpdateUserStatistics</a>
                        </span>

                            <div class="summary">
                                Updates the values of the specified title-specific statistics for the user
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Title-Wide Data Management">Title-Wide Data Management</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCatalogItems">GetCatalogItems</a>
                        </span>

                            <div class="summary">
                                Retrieves the specified version of the 
title's catalog of virtual goods, including all defined properties
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetStoreItems">GetStoreItems</a>
                        </span>

                            <div class="summary">
                                Retrieves the set of items defined for the specified store, including all prices defined
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetTitleData">GetTitleData</a>
                        </span>

                            <div class="summary">
                                Retrieves the key-value store of custom title settings
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetTitleNews">GetTitleNews</a>
                        </span>

                            <div class="summary">
                                Retrieves the title news feed, as configured in the developer portal
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Player Item Management">Player Item Management</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/AddUserVirtualCurrency">AddUserVirtualCurrency</a>
                        </span>

                            <div class="summary">
                                Increments the user's balance of the specified virtual currency by the stated amount
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/ConsumeItem">ConsumeItem</a>
                        </span>

                            <div class="summary">
                                Consume uses of a consumable item. When 
all uses are consumed, it will be removed from the player's inventory.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCharacterInventory">GetCharacterInventory</a>
                        </span>

                            <div class="summary">
                                Retrieves the specified character's current inventory of virtual goods
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetUserInventory">GetUserInventory</a>
                        </span>

                            <div class="summary">
                                Retrieves the user's current inventory of virtual goods
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RedeemCoupon">RedeemCoupon</a>
                        </span>

                            <div class="summary">
                                Adds the virtual goods associated with the coupon to the user's inventory
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/ReportPlayer">ReportPlayer</a>
                        </span>

                            <div class="summary">
                                Submit a report for another player (due 
to bad bahavior, etc.), so that customer service representatives for the
 title can take action concerning potentially toxic players.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/SubtractUserVirtualCurrency">SubtractUserVirtualCurrency</a>
                        </span>

                            <div class="summary">
                                Decrements the user's balance of the specified virtual currency by the stated amount
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UnlockContainerItem">UnlockContainerItem</a>
                        </span>

                            <div class="summary">
                                Unlocks a container item in the user's 
inventory and consumes a key item of the type indicated by the container
 item
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/StartPurchase">StartPurchase</a>
                        </span>

                            <div class="summary">
                                Creates an order for a list of items from the title catalog
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/PayForPurchase">PayForPurchase</a>
                        </span>

                            <div class="summary">
                                Selects a payment option for purchase order created via StartPurchase
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/ConfirmPurchase">ConfirmPurchase</a>
                        </span>

                            <div class="summary">
                                Confirms with the payment provider that 
the purchase was approved (if applicable) and adjusts inventory and 
virtual currency balances as appropriate
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/PurchaseItem">PurchaseItem</a>
                        </span>

                            <div class="summary">
                                Buys a single item with virtual 
currency. You must specify both the virtual currency to use to purchase,
 as well as what the client believes the price to be. This lets the 
server fail the purchase if the price has changed.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Friend List Management">Friend List Management</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/AddFriend">AddFriend</a>
                        </span>

                            <div class="summary">
                                Adds the PlayFab user, based upon a 
match against a supplied unique identifier, to the friend list of the 
local user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetFriendsList">GetFriendsList</a>
                        </span>

                            <div class="summary">
                                Retrieves the current friend list for 
the local user, constrained to users who have PlayFab accounts. Friends 
from linked accounts (Facebook, Steam) are also included. You may 
optionally exclude some linked services' friends.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RemoveFriend">RemoveFriend</a>
                        </span>

                            <div class="summary">
                                Removes a specified user from the friend list of the local user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/SetFriendTags">SetFriendTags</a>
                        </span>

                            <div class="summary">
                                Updates the tag list for a specified user in the friend list of the local user
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="IOS-Specific APIs">IOS-Specific APIs</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RegisterForIOSPushNotification">RegisterForIOSPushNotification</a>
                        </span>

                            <div class="summary">
                                Registers the iOS device to receive push notifications
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RestoreIOSPurchases">RestoreIOSPurchases</a>
                        </span>

                            <div class="summary">
                                Restores all in-app purchases based on the given refresh receipt.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/ValidateIOSReceipt">ValidateIOSReceipt</a>
                        </span>

                            <div class="summary">
                                Validates with the Apple store that the 
receipt for an iOS in-app purchase is valid and that it matches the 
purchased catalog item
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Matchmaking APIs">Matchmaking APIs</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCurrentGames">GetCurrentGames</a>
                        </span>

                            <div class="summary">
                                Get details about all current running game servers matching the given parameters.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetGameServerRegions">GetGameServerRegions</a>
                        </span>

                            <div class="summary">
                                 Get details about the regions hosting game servers matching the given parameters.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/Matchmake">Matchmake</a>
                        </span>

                            <div class="summary">
                                Attempts to locate a game session 
matching the given parameters. Note that parameters specified in the 
search are
required (they are not weighting factors). If a slot is found in a 
server instance matching the parameters, the slot will be assigned to
that player, removing it from the availabe set. In that case, the 
information on the game session will be returned, otherwise the Status
returned will be GameNotFound. Note that EnableQueue is deprecated at 
this time.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/StartGame">StartGame</a>
                        </span>

                            <div class="summary">
                                Start a new game server with a given 
configuration, add the current player and return the connection 
information.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Android-Specific APIs">Android-Specific APIs</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/AndroidDevicePushNotificationRegistration">AndroidDevicePushNotificationRegistration</a>
                        </span>

                            <div class="summary">
                                Registers the Android device to receive push notifications
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/ValidateGooglePlayPurchase">ValidateGooglePlayPurchase</a>
                        </span>

                            <div class="summary">
                                Validates a Google Play purchase and gives the corresponding item to the player.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Analytics">Analytics</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/LogEvent">LogEvent</a>
                        </span>

                            <div class="summary">
                                Logs a custom analytics event
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Shared Group Data">Shared Group Data</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/AddSharedGroupMembers">AddSharedGroupMembers</a>
                        </span>

                            <div class="summary">
                                Adds users to the set of those able to 
update both the shared data, as well as the set of users in the group. 
Only users in the group can add new members.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/CreateSharedGroup">CreateSharedGroup</a>
                        </span>

                            <div class="summary">
                                Requests the creation of a shared group 
object, containing key/value pairs which may be updated by all members 
of the group. Upon creation, the current user will be the only member of
 the group.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetPublisherData">GetPublisherData</a>
                        </span>

                            <div class="summary">
                                Retrieves the key-value store of custom publisher settings
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetSharedGroupData">GetSharedGroupData</a>
                        </span>

                            <div class="summary">
                                Retrieves data stored in a shared group 
object, as well as the list of members in the group. Non-members
of the group may use this to retrieve group data, including membership, 
but they will not receive data for keys marked as private.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RemoveSharedGroupMembers">RemoveSharedGroupMembers</a>
                        </span>

                            <div class="summary">
                                Removes users from the set of those able to update the shared data and the set of users in the
group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group
and its associated data will be deleted.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UpdateSharedGroupData">UpdateSharedGroupData</a>
                        </span>

                            <div class="summary">
                                Adds, updates, and removes data keys for
 a shared group object. If the permission is set to Public,
all fields updated or added in this call will be readable by users not 
in the group. By default, data permissions are set
to Private. Regardless of the permission setting, only members of the 
group can update the data.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Sony-specific APIs">Sony-specific APIs</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RefreshPSNAuthToken">RefreshPSNAuthToken</a>
                        </span>

                            <div class="summary">
                                Uses the supplied OAuth code to refresh the internally cached player PSN auth token
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Server-Side Cloud Script">Server-Side Cloud Script</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCloudScriptUrl">GetCloudScriptUrl</a>
                        </span>

                            <div class="summary">
                                Retrieves the title-specific URL for Cloud Script servers. This must be queried once, prior 
to making any calls to RunCloudScript.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/RunCloudScript">RunCloudScript</a>
                        </span>

                            <div class="summary">
                                Triggers a particular server action, passing the provided inputs to the hosted Cloud Script.
An action in this context is a handler in the JavaScript. NOTE: Before calling this API, you must call GetCloudScriptUrl
to be assigned a Cloud Script server URL. When using an official PlayFab SDK, this URL is stored internally in the SDK,
but GetCloudScriptUrl must still be manually called.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Content">Content</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetContentDownloadUrl">GetContentDownloadUrl</a>
                        </span>

                            <div class="summary">
                                Retrieves the pre-authorized URL for 
accessing a content file for the title. A subsequent HTTP GET to the 
returned URL downloads the content; or a HEAD query to the returned URL 
retrieves the metadata of the content. This API only generates a 
pre-signed URL to access the content. A success result does not 
guarantee the existence of the content.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Characters">Characters</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCharacterLeaderboard">GetCharacterLeaderboard</a>
                        </span>

                            <div class="summary">
                                Retrieves a list of ranked characters 
for the given statistic, starting from the indicated point in the 
leaderboard
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetLeaderboardAroundCharacter">GetLeaderboardAroundCharacter</a>
                        </span>

                            <div class="summary">
                                Retrieves a list of ranked characters 
for the given statistic, centered on the currently signed-in user
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetLeaderboardForUserCharacters">GetLeaderboardForUserCharacters</a>
                        </span>

                            <div class="summary">
                                Retrieves a list of all of the user's characters for the given statistic.
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GrantCharacterToUser">GrantCharacterToUser</a>
                        </span>

                            <div class="summary">
                                Grants the specified character type to the user.
                            </div>
                    </li>
                        <li>
                            <span class="subsectionheading" id="Character Data">Character Data</span>
                        </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCharacterData">GetCharacterData</a>
                        </span>

                            <div class="summary">
                                Retrieves the title-specific custom data
 for the character which is readable and writable by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/GetCharacterReadOnlyData">GetCharacterReadOnlyData</a>
                        </span>

                            <div class="summary">
                                Retrieves the title-specific custom data for the character which can only be read by the client
                            </div>
                    </li>
                    <li>
                        <span>
                            <a href="https://api.playfab.com/Documentation/Client/method/UpdateCharacterData">UpdateCharacterData</a>
                        </span>

                            <div class="summary">
                                Creates and updates the title-specific custom data for the user's character which is readable 
and writable by the client
                            </div>
                    </li>
            </ul>
        </section>
</div>

    </div>

    <!--Start Footer-->
    <div class="footerDiv" style="margin-top:50px;">
        <div class="footerLinks">
            <a href="https://playfab.com/about.html"><span>Who we are</span></a>
            <a href="https://www.linkedin.com/company/playfab-inc-?trk=tabs_biz_home"><span>Jobs</span></a>
            <a href="https://playfab.com/policies.html"><span>Privacy Policy</span></a>
            <a href="https://playfab.com/use.html"><span>Acceptable Use</span></a>
            <a href="https://playfab.com/terms.html"><span>Terms of Service</span></a>
        </div>
        <div class="socialButtons">
            <a href="https://www.youtube.com/channel/UCh3G2vHGMFTYyQN1QMOUspw"><img src="README_files/youtubelogo.png" width="32"></a>
            <a href="https://www.facebook.com/playfabnetwork"><img src="README_files/facebooklogo.png" width="32"></a>
            <a href="https://twitter.com/playfabnetwork"><img src="README_files/twitterlogo.png" width="32"></a>
            <a href="http://www.linkedin.com/company/playfab-inc-?trk=tabs_biz_home"><img src="README_files/linkedinlogo.png" width="32"></a>
        </div>
    </div>
    <div class="boilerplateWrapperDiv">
		©2014 PlayFab, Inc. All rights reserved. PlayFab® is a registered trademark of PlayFab, Inc.
    </div>
    <!--End Footer-->



</body></html>