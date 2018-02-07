<?php
/**
 * 恋爱性格测试模块微站定义
 *
 * @author xiongyingjie
 * @url 
 */
defined('IN_IA') or exit('Access Denied');

class Panda_musicModuleSite extends WeModuleSite {

public function doMobileInit() {
        global $_W, $_GPC;
        load()->func('tpl');
        include $this->template('Init');
    }

}