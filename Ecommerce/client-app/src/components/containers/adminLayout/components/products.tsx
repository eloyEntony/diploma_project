import React, { useState, useEffect, FC, useRef } from 'react';

import { useActions } from "../../../../hooks/useActions";
import { useTypedSelector } from "../../../../hooks/useTypedSelector";
import { ListBox } from 'primereact/listbox';
import { classNames } from 'primereact/utils';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Toast } from 'primereact/toast';
import { Button } from 'primereact/button';
import { FileUpload } from 'primereact/fileupload';
import { Rating } from 'primereact/rating';
import { Toolbar } from 'primereact/toolbar';
import { InputTextarea } from 'primereact/inputtextarea';
import { RadioButton } from 'primereact/radiobutton';
import { InputNumber } from 'primereact/inputnumber';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';

const Products: FC = () => {

    const { products, loading } = useTypedSelector((store) => store.product);
    const { fetchProducts } = useActions();

    useEffect(() => {
        fetchProducts();
    }, [])
/////////////////////
    const toast = useRef(null);
    const dt = useRef(null);
    const [globalFilter, setGlobalFilter] = useState(null);
    const [selectedProducts, setSelectedProducts] = useState(null);


    const openNew = () => {
        
    }
    const confirmDeleteSelected = () => {
       
    }
    const leftToolbarTemplate = () => {
        return (
            <React.Fragment>
                <Button label="New" icon="pi pi-plus" className="p-button-success p-mr-2" onClick={openNew} />
                <Button label="Delete" icon="pi pi-trash" className="p-button-danger" onClick={confirmDeleteSelected} />
            </React.Fragment>
        )
    }

    const rightToolbarTemplate = () => {
        return (
            <React.Fragment>
                <FileUpload mode="basic" name="demo[]" auto url="https://primefaces.org/primereact/showcase/upload.php" accept=".csv" chooseLabel="Import" className="p-mr-2 p-d-inline-block"  />
                <Button label="Export" icon="pi pi-upload" className="p-button-help"  />
            </React.Fragment>
        )
    }
    const header = (
        <div className="table-header">
            <h5 className="p-mx-0 p-my-1">Manage Products</h5>
            <span className="p-input-icon-left">
                <i className="pi pi-search" />
                <InputText type="search"  placeholder="Search..." />
            </span>
        </div>
    );

    const imageBodyTemplate = (rowData:any) => {
        return <img src={`showcase/demo/images/product/${rowData.image}`} 
        // onError={(e) => e.target.src='https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png'} 
        alt={rowData.image} className="product-image" />
    }
    const formatCurrency = (value:any) => {
        return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    }
    const priceBodyTemplate = (rowData:any) => {
        return formatCurrency(rowData.price);
    }

    const ratingBodyTemplate = (rowData:any) => {
        return <Rating value={rowData.rating} readOnly cancel={false} />;
    }

    const statusBodyTemplate = (rowData:any) => {
        // return <span className={`product-badge status-${rowData.inventoryStatus.toLowerCase()}`}>{rowData.inventoryStatus}</span>;
    }
    const actionBodyTemplate = (rowData:any) => {
        return (
            <React.Fragment>
                <Button icon="pi pi-pencil" className="p-button-rounded p-button-success p-mr-2" 
                // onClick={() => editProduct(rowData)} 
                />
                <Button icon="pi pi-trash" className="p-button-rounded p-button-warning" 
                // onClick={() => confirmDeleteProduct(rowData)}
                 />
            </React.Fragment>
        );
    }

    return (
        <>
            {/* <ListBox 
           options={products}            
           optionLabel="name"  /> */}

            <div className="datatable-crud-demo">
                <Toast ref={toast} />

                <div className="card">
                    <Toolbar className="p-mb-4" left={leftToolbarTemplate} right={rightToolbarTemplate}></Toolbar>

                    <DataTable ref={dt} value={products} selection={selectedProducts} onSelectionChange={(e) => setSelectedProducts(e.value)}
                        dataKey="id" paginator rows={10} rowsPerPageOptions={[5, 10, 25]}
                        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                        currentPageReportTemplate="Showing {first} to {last} of {totalRecords} products"
                        globalFilter={globalFilter} header={header} responsiveLayout="scroll">
                        <Column selectionMode="multiple" headerStyle={{ width: '3rem' }} exportable={false}></Column>
                        <Column field="code" header="Code" sortable style={{ minWidth: '12rem' }}></Column>
                        <Column field="name" header="Name" sortable style={{ minWidth: '16rem' }}></Column>
                        {/* <Column field="image" header="Image" body={imageBodyTemplate}></Column> */}
                        <Column field="price" header="Price" body={priceBodyTemplate} sortable style={{ minWidth: '8rem' }}></Column>
                        <Column field="category" header="Category" sortable style={{ minWidth: '10rem' }}></Column>
                        <Column field="rating" header="Reviews" body={ratingBodyTemplate} sortable style={{ minWidth: '12rem' }}></Column>
                        <Column field="inventoryStatus" header="Status" body={statusBodyTemplate} sortable style={{ minWidth: '12rem' }}></Column>
                        <Column body={actionBodyTemplate} exportable={false} style={{ minWidth: '8rem' }}></Column>
                    </DataTable>
                </div>                
            </div>
        </>

    )
}
export default Products;