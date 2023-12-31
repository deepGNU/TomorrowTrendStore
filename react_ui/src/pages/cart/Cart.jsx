import './Cart.css'
import React from 'react'
import { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { fetchCart } from '../../api/resources/carts'
import { checkoutAPI } from '../../api/resources/carts'
import CartLine from '../../components/orderline/CartLine'
import BtnNeon from '../../components/buttons/BtnNeon'

const Cart = () => {
  const dispatch = useDispatch()
  const cart = useSelector(state => state.carts.loggedInUserCart);
  const isLoggedIn = useSelector(state => state.currentUser.isLoggedIn)

  useEffect(() => {
    if (isLoggedIn) {
      fetchCart(dispatch)
    }
  }, [dispatch, isLoggedIn])

  const handleCheckout = () => {
    checkoutAPI(dispatch, cart.id)
  }

  return (
    <>
      {!cart ?
        (<h2 className='cart'>Cart is empty</h2>) : (
          <div className='cart'>
            <BtnNeon className='notice-me' text={'Checkout'} onClick={handleCheckout} />
            <div>Total price: {cart?.totalPrice ?? 0}</div>
            {cart?.orderLines?.map(ol => <CartLine key={ol.id} orderLine={ol} />)}
          </div>
        )
      }
    </>
  )
}

export default Cart