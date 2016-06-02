<?php
    class Template
    {
        //Fields
        private $variables = array();
        private $controller;
        private $action;
        
        //Properties
        public function set($name, $value)
        {
            $this->variables[$name] = $value;            
        }        
       
        //Constructor
        public function __construct($controller, $action)
        {
            $this->controller = $controller;
            $this->action = $action;            
        } 
        
        public function render()
        {
            //var_dump($this->variables);
            extract($this->variables);
            
            include(ROOT.DS.'application'.DS.'views'.DS.'head.php');
            include(ROOT.DS.'application'.DS.'views'.DS.'header.php');
            include(ROOT.DS.'application'.DS.'views'.DS.'mainmenu.php');
            
            if (file_exists(ROOT.DS.'application'.DS.'views'.DS.$this->controller.DS.$this->action.'.php'))
            {
                include(ROOT.DS.'application'.DS.'views'.DS.$this->controller.DS.$this->action.'.php');
            }
            else
            {
                echo "View: ".$this->action." bestaat niet";
            }
            
            include(ROOT.DS.'application'.DS.'views'.DS.'footer.php');            
        }
    }
?>