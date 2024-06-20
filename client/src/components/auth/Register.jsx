import { useEffect, useState } from "react";
import { register } from "../../managers/authManager";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, Label } from "reactstrap";
import { getAllGenres } from "../../managers/genreManager";
import { getAllTypes } from "../../managers/typeManager";

export default function Register({ setLoggedInUser }) {
  const [genres, setGenres] = useState([]);
  const [types, setTypes] = useState([]);

  const [profilePictureUrl, setProfilePictureUrl] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [location, setLocation] = useState("");
  const [typeId, setTypeId] = useState(null); // Changed to null
  const [genreId, setGenreId] = useState(null); // Changed to null
  const [address, setAddress] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const [passwordMismatch, setPasswordMismatch] = useState(false);
  const [registrationFailure, setRegistrationFailure] = useState(false);

  const navigate = useNavigate();

  useEffect(() => {
    getAllGenres().then(setGenres);
  }, []);

  useEffect(() => {
    getAllTypes().then(setTypes);
  }, []);

  const handleGenreChange = (e) => {
    setGenreId(parseInt(e.target.value)); // Parse the selected value to integer
  };

  const handleTypeChange = (e) => {
    setTypeId(parseInt(e.target.value)); // Parse the selected value to integer
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      const newUser = {
        firstName,
        lastName,
        userName,
        email,
        address,
        password,
        typeId, // Ensure typeId is passed correctly
        location,
        profilePictureUrl,
        genreId, // Ensure genreId is passed correctly
      };

      console.log("Submitting new user:", newUser); // Log user data

      register(newUser)
        .then((user) => {
          if (user) {
            setLoggedInUser(user);
            navigate("/");
          } else {
            console.error("Registration failed:", user); // Log error response
            setRegistrationFailure(true);
          }
        })
        .catch((error) => {
          console.error("Error during registration:", error); // Log any errors
          setRegistrationFailure(true);
        });
    }
  };

  return (
    <div className="container" style={{ maxWidth: "500px" }}>
      <h3>Sign Up</h3>
      <FormGroup>
        <Label>Profile Picture Url</Label>
        <Input
          type="text"
          value={profilePictureUrl}
          onChange={(e) => {
            setProfilePictureUrl(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>First Name</Label>
        <Input
          type="text"
          value={firstName}
          onChange={(e) => {
            setFirstName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Last Name</Label>
        <Input
          type="text"
          value={lastName}
          onChange={(e) => {
            setLastName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Email</Label>
        <Input
          type="email"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>User Name</Label>
        <Input
          type="text"
          value={userName}
          onChange={(e) => {
            setUserName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Location</Label>
        <Input
          type="text"
          value={location}
          onChange={(e) => {
            setLocation(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Address</Label>
        <Input
          type="text"
          value={address}
          onChange={(e) => {
            setAddress(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Genre</Label>
        <select
          name="genreId"
          className="form-control"
          onChange={handleGenreChange}
        >
          <option value="">Select Genre</option>
          {genres.map((genre) => (
            <option key={genre.id} value={genre.id}>
              {genre.name}
            </option>
          ))}
        </select>
      </FormGroup>
      <FormGroup>
        <Label>Type</Label>
        <select
          name="typeId"
          className="form-control"
          onChange={handleTypeChange}
        >
          <option value="">Select Type</option>
          {types.map((type) => (
            <option key={type.id} value={type.id}>
              {type.name}
            </option>
          ))}
        </select>
      </FormGroup>
      <FormGroup>
        <Label>Password</Label>
        <Input
          invalid={passwordMismatch}
          type="password"
          value={password}
          onChange={(e) => {
            setPasswordMismatch(false);
            setPassword(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Confirm Password</Label>
        <Input
          invalid={passwordMismatch}
          type="password"
          value={confirmPassword}
          onChange={(e) => {
            setPasswordMismatch(false);
            setConfirmPassword(e.target.value);
          }}
        />
        <FormFeedback>Passwords do not match!</FormFeedback>
      </FormGroup>
      <p style={{ color: "red" }} hidden={!registrationFailure}>
        Registration Failure
      </p>
      <Button
        color="primary"
        onClick={handleSubmit}
        disabled={passwordMismatch || !typeId || !genreId}
      >
        Register
      </Button>
      <p>
        Already signed up? Log in <Link to="/login">here</Link>
      </p>
    </div>
  );
}
