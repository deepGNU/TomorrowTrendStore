import './Nav.css'
import React from 'react'
import { NavLink } from 'react-router-dom'
import BtnLogInOrOut from '../buttons/BtnLogInOrOut'
import ControlPanel from '../control-panel/ControlPanel'
// import { useEffect } from 'react'
import { useSelector } from 'react-redux'

const Nav = () => {
    const cartIsNotEmpty = useSelector(state => state.carts.loggedInUserCart?.orderLines?.length > 0)

    return (
        <nav className='nav-bar'>
            <NavLink className={({ isActive }) => `nav-bar-link ${isActive ? 'active-nav-link' : ''}`} to='/'>Home</NavLink>
            <NavLink className={({ isActive }) => `nav-bar-link ${isActive ? 'active-nav-link' : ''}`} to='/products'>Products</NavLink>
            <NavLink className={({ isActive }) => `nav-bar-link ${isActive ? 'active-nav-link' : ''}`} to='/my-orders'>My Orders</NavLink>
            <NavLink className={({ isActive }) => `nav-bar-link ${isActive ? 'active-nav-link' : ''}`} to='/my-profile'>My Profile</NavLink>
            <NavLink className={({ isActive }) => `nav-bar-link ${isActive ? 'active-nav-link' : ''}`} to='/about'>About</NavLink>
            <NavLink className={({ isActive }) => `nav-bar-link ${isActive ? 'active-nav-link' : (cartIsNotEmpty ? 'cart-has-contents' : '')}`} to='/cart'>Cart</NavLink>
            <ControlPanel />
            <BtnLogInOrOut />
        </nav>
    )
}

export default Nav