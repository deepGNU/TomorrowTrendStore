import './Orders.css';
import React, { useEffect } from 'react';
import { getOrdersAPI } from '../../api/resources/orders';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import Orders from '../../components/orders/Orders';
import BtnNeon from '../../components/buttons/BtnNeon';

function OrdersPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const orders = useSelector(state => state.orders.orders);

    const handleAddOrderClick = () => {
        navigate('/order-form')
    };

    useEffect(() => {
        getOrdersAPI(dispatch);
    }, [dispatch]);

    return (
        <>
            <div className="top-section">
                <h1>Manage Orders</h1>
                <BtnNeon text={'Add Order'} onClick={handleAddOrderClick} />
            </div>
            <div className='orders-page'>
                <Orders orders={orders} />
            </div>
        </>
    );
}

export default OrdersPage;
