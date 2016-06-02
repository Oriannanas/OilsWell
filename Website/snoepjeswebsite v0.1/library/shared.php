<?php
 function callHook()
 {
     global $url;
     $urlArray = explode('/', $url);     
     $controller = $urlArray[0];      
     array_shift($urlArray);     
     $action = $urlArray[0]; 
     array_shift($urlArray);
     $queryString = $urlArray; 
     $controllerName = strtolower($controller); 
     $controller = ucwords(strtolower($controller));
     $model = rtrim($controller, 's'); 
     $controller = $controller."Controller";
     $dispatch = new $controller($model, $controllerName, $action);     
     
     if (method_exists($controller, $action))
     {         
         call_user_func_array(array($dispatch, $action), $queryString);         
     }
     else
     {
         echo "method '".$action."' bestaat niet";
     }    
 }

 function __autoload($classname)
 {
     if (file_exists(ROOT.DS.'application'.DS.'controllers'.DS.strtolower($classname).'.php'))
     {
         require_once(ROOT.DS.'application'.DS.'controllers'.DS.strtolower($classname).'.php');
     }
     else if (file_exists(ROOT.DS.'application'.DS.'models'.DS.strtolower($classname).'.php'))
     {
         require_once(ROOT.DS.'application'.DS.'models'.DS.strtolower($classname).'.php');
     }
     else if (file_exists(ROOT.DS.'library'.DS.strtolower($classname).'.class.php'))
     {
         require_once(ROOT.DS.'library'.DS.strtolower($classname).'.class.php');
     }
     else
     {
         echo $classname.'class not found';
     }
 }

 callHook();
?>