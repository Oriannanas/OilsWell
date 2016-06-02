<?php
 class Controller
 {
    // Fields
    protected $model;
    protected $controller;
    protected $action;
    protected $template;  
     
    // Properties
    public function set($name, $value)
    {
        $this->template->set($name, $value);
    }   
     
    // Constructor
    public function __construct($model, $controller, $action)
    {
        $this->model = new $model(); 
        $this->controller = $controller;
        $this->action = $action;
        $this->template = new Template($controller, $action);        
    }
     
    public function __destruct()
    {
        $this->template->render();
    }     
 }
?>