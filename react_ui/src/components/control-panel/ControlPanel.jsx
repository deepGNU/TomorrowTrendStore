import './ControlPanel.css';
import { useSelector } from 'react-redux';
import { NavLink } from 'react-router-dom';

const ControlPanel = () => {
    const isAuthorized = useSelector(state => state.currentUser.isAuthorizedForControlPanel)

    if (!isAuthorized) {
        return null;
    }

    return (
        <div className={`control-panel`}>
            <div>Manage Store</div>

            <nav className="drop-down-menu">
                <NavLink className='nav-bar-link' to='/orders'>
                    <span>Manage</span>
                    <span>Orders</span>
                </NavLink>

                <NavLink className='nav-bar-link' to='/edit-products'>
                    <span>Manage</span>
                    <span>Products</span>
                </NavLink>

                <NavLink className='nav-bar-link' to='/users'>
                    <span>Manage</span>
                    <span>Users</span>
                </NavLink>
            </nav>
        </div>
    );
};

export default ControlPanel;
