import React, { useState } from 'react';
import { ListBox } from 'primereact/listbox';
const Users = () => {

    const [selectedCity, setSelectedCity] = useState(null);
   

    const cities = [
        { name: 'New York', code: 'NY' },
        { name: 'Rome', code: 'RM' },
        { name: 'London', code: 'LDN' },
        { name: 'Istanbul', code: 'IST' },
        { name: 'Paris', code: 'PRS' }
    ];
   

    return (
        <>
        <h2>Users list</h2>
                    <ListBox value={selectedCity} options={cities} onChange={(e) => setSelectedCity(e.value)} optionLabel="name"  />
</>

    );
}
          
export default Users;