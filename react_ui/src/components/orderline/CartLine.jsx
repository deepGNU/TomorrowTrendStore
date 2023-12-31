import './OrderLine.css'
import React from 'react'
import { removeFromCart } from '../../api/resources/carts'
import { updateOrderLineAPI } from '../../api/resources/carts'
import { useDispatch } from 'react-redux'

const CartLine = ({ orderLine }) => {
    const dispatch = useDispatch()

    const handleDelete = () => {
        removeFromCart(dispatch, orderLine.shopOrderId, orderLine.id)
    }

    const handleQuantityUpdate = (e) => {
        updateOrderLineAPI(dispatch, orderLine.shopOrderId, orderLine.id, e.target.value)
    }

    return (
        <div className='orderline-wrapper'>
            <h2>{orderLine.product.name}</h2>
            <div className='orderline-div'>
                <img src={orderLine.product.imageURL} alt="Product" />

                <p>Price: {orderLine.price}</p>

                <div>
                    <div>Quantity</div>
                    <select
                        onChange={handleQuantityUpdate}
                        value={orderLine?.quantity}
                        name="quantity"
                        id="quantity"
                        className='neon-sign quantity-select'
                    >
                        <option value={orderLine?.quantity}>{orderLine?.quantity}</option>
                        <option value={1}>1</option>
                        <option value={2}>2</option>
                        <option value={3}>3</option>
                    </select>
                </div>

                <button className='neon-sign' onClick={handleDelete}>Delete</button>
            </div>
        </div>
    )
}

export default CartLine