import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavbarText,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "./posts/Post.css";
export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar className="mb-3" light fixed="top" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          Cadence Collab
        </NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} />
        <Collapse isOpen={open} navbar>
          <Nav className="me-auto" navbar>
            {loggedInUser ? (
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/">
                    Home
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/newpost">
                    New Post
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/explore">
                    Explore
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/profile">
                    Profile
                  </NavLink>
                </NavItem>
              </>
            ) : (
              <NavItem>
                <NavLink tag={RRNavLink} to="/login">
                  <Button color="primary">Login</Button>
                </NavLink>
              </NavItem>
            )}
          </Nav>
          {loggedInUser && (
            <NavbarText>
              <Button
                color="primary"
                onClick={(e) => {
                  e.preventDefault();
                  setOpen(false);
                  logout().then(() => {
                    setLoggedInUser(null);
                  });
                }}
              >
                Logout
              </Button>
            </NavbarText>
          )}
        </Collapse>
      </Navbar>
    </div>
  );
}
