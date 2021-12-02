import React, {useState} from 'react'
import { TabMenu } from 'primereact/tabmenu';
import { Button } from 'primereact/button';



const Header =()=>{

    const items = [
        {label: 'Home', icon: 'pi pi-fw pi-home'},
        {label: 'Calendar', icon: 'pi pi-fw pi-calendar'},
        {label: 'Edit', icon: 'pi pi-fw pi-pencil'},
        {label: 'Documentation', icon: 'pi pi-fw pi-file'},
        {label: 'Settings', icon: 'pi pi-fw pi-cog'}
    ];

    return (
        <div>
            <div className="card">
                <h5>Eccomerce</h5>
                <TabMenu model={items} />
            </div>

           
        </div>
    );
}
export default Header