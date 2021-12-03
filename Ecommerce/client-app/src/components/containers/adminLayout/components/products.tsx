import React, { useState, useEffect, FC } from 'react';

import { useActions } from "../../../../hooks/useActions";
import { useTypedSelector } from "../../../../hooks/useTypedSelector";
import { ListBox } from 'primereact/listbox';

const Products: FC =()=> {
    
    const { products, loading } = useTypedSelector((store) => store.product);
    const { fetchProducts } = useActions();

    useEffect(()=>{
        fetchProducts();
    }, [])

    return (
        <>
           <ListBox 
           options={products}            
           optionLabel="name"  />

        </>
        
    )
}
export default Products;