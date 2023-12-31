import React from 'react'

const OrderLine = ({orderLine}) => {
  return (
    <div className='orderline-wrapper'>
            <h2>{orderLine.product.name}</h2>
            <div className='orderline-div'>
                <img src={orderLine.product.imageURL} alt="Product" />

                <p>Price: {orderLine.price}</p>

                <div>
                    <div>Quantity: {orderLine.quantity}</div>
                    
                </div>
            </div>
        </div>
  )
}

export default OrderLine