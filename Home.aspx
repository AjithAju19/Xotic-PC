<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
		<script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<!-- Carousel begins..-->
		<div>
			<div class="container">
				<h2>Carousel Example</h2>
				<div id="myCarousel" class="carousel slide" data-ride="carousel">
					<!-- Indicators -->
					<ol class="carousel-indicators">
						<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
						<li data-target="#myCarousel" data-slide-to="1"></li>
						<li data-target="#myCarousel" data-slide-to="2"></li>
						<li data-target="#myCarousel" data-slide-to="3"></li>
						<li data-target="#myCarousel" data-slide-to="4"></li>
					</ol>
					<!-- Wrapper for slides -->
					<div class="carousel-inner">
						<div class="item active"> <img src="icons/game-ready.jpg" alt="Los Angeles" style="width:100%;">
							<div class="carousel-caption">
								<p><a class="btn btn-lg btn-primary" href="Products.aspx" role="button">Buy now</a></p>
							</div>
						</div>
						<br />
						<br />
						<br />
						<br />
						<div class="item"> <img src="icons/geforce-max-q-fb-evens-3c33-D@2x.jpg" alt="Chicago" style="width:100%;"> </div>
						<div class="item"> <img src="icons/geforce-rtx-20-series-laptop.jpg" alt="New york" style="width:100%;"> </div>
						<div class="item"> <img src="icons/geforce.jpg" alt="New york" style="width:100%;"> </div>
						<div class="item"> <img src="icons/nvidia-rtx-games.jpg" alt="New york" style="width:100%;"> </div>
					</div>
					<!-- Left and right controls -->
					<a class="left carousel-control" href="#myCarousel" data-slide="prev"> <span class="glyphicon glyphicon-chevron-left"></span> <span class="sr-only">Previous</span> </a>
					<a class="right carousel-control" href="#myCarousel" data-slide="next"> <span class="glyphicon glyphicon-chevron-right"></span> <span class="sr-only">Next</span> </a>
				</div>
			</div>
		</div>
		<br />
		<!--Middle content starts -->
		<div class="container center">
			<div class="row">
				<div class="col-lg-4"> <img src="icons/maxresdefault-1_1024x1024.jpg" alt="thumb" width="140" height="140" />
					<h4>MOBILE 3000 SERIES RTX AMPERE</h4>
					<p>GeForce RTX™ 30 Series GPUs power the world’s fastest laptops for gamers and creators. They’re built with the award-winning Ampere—NVIDIA’s...</p>
					<!--     <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p> -->
				</div>
				<div class="col-lg-4"> <img src="icons/radeon_1024x1024.png" alt="thumb" width="140" height="140" />
					<h4>PERFORMANCE TO RULE YOUR GAME AND RX 6000 Series</h4>
					<p>Introducing the AMD Radeon™ RX 6000 Series graphics cards, featuring the breakthrough AMD RDNA™ 2 architecture, engineered to deliver powerhouse...</p>
					<!--     <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p> -->
				</div>
				<div class="col-lg-4"> <img src="icons/5000series_1024x1024.png" alt="thumb" width="140" height="140" />
					<h4>BE UNSTOPPABLE WITH NEW AMD RYZEN 5000 SERIES</h4>
					<p>Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD RYZEN 5000 Series processors deliver the ultimate in high...</p>
					<!--    <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p> -->
				</div>
				<div class="col-lg-4"> <img src="icons/desktop3000_1024x1024.png" alt="thumb" width="140" height="140" />
					<h4>GEOFORCE RTX 30 SERIES PCS THE ULTIMATE PLAY</h4>
					<p>PCs equipped with GeForce RTX™ 30 Series GPUs deliver the ultimate performance for gamers and creators. They’re powered by Ampere—NVIDIA’s...</p>
					<!--  <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p> -->
				</div>
			</div>
		</div>
		<!--Middle Content closes-->
		<br />
		<br />
		<br />
		<div class="portfolio">
			<h1 class="title">XOTIC PC LIVE</h1>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://storage-asset.msi.com/event/2019/mystic-light-rgb-pc/images/partner01.jpg" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://www.howtogeek.com/wp-content/uploads/2021/05/rgb_header.jpg?width=1198&trim=1,1&bg-color=000&pad=1,1" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://www.nubgamerz.com/wp-content/uploads/2021/02/blog.jpg" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://gearopen.com/wp-content/uploads/2021/06/Untitled1569-768x548.png" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://images.unsplash.com/photo-1593508512255-86ab42a8e620?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1398&q=80" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://progameguides.com/wp-content/uploads/2021/10/rgbsetup-1.jpg" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://www.howtogeek.com/wp-content/uploads/2021/06/rbg_gear.jpg?trim=1,1&bg-color=000&pad=1,1" alt="" /> </div>
			</a>
			<a href="#" class="card">
				<div class="content"> <span class="title">Gaming PC/ Laptops</span> <span class="category">MSI / Razer / Alienware </span> </div>
				<div class="image"> <img src="https://storage-asset.msi.com/event/2019/mystic-light-rgb-pc/images/partner01.jpg" alt="" /> </div>
			</a>
		</div>
		<br />
		<br />
		<br />
		<br />
		<br />
		<style type="text/css">
		.title {
			color: white;
		}
		
		.portfolio {
			display: flex;
			flex-wrap: wrap;
			min-width: 320px;
		}
		
		.portfolio h1 {
			flex-basis: 100%;
			text-align: center;
			margin: 50px auto 30px;
			text-transform: uppercase;
			font-size: 20px;
			letter-spacing: 2px;
			color: #fff;
		}
		
		.card {
			width: 25%;
			overflow: hidden;
			position: relative;
		}
		
		.card .content {
			z-index: 2;
			width: 100%;
			position: absolute;
			bottom: -100px;
			transition: all 0.7s ease;
			display: flex;
			flex-direction: column;
			align-items: center;
			padding: 20px;
			box-sizing: border-box;
			min-height: 100px;
			background: #111;
		}
		
		.card .image {
			z-index: 1;
			height: 100%;
		}
		
		.card img {
			height: 100%;
			width: 100%;
			transition: all 0.5s ease;
			transform: scale(1.2);
		}
		
		.card:hover .content {
			bottom: 0px;
			color: #fff;
		}
		
		.card:hover .image img {
			transform: scale(1);
		}
		
		.card .content span:first-child {
			text-transform: uppercase;
			margin-bottom: 10px;
			font-weight: 700;
			letter-spacing: 1px;
			text-align: center;
			color: #fff;
			font-size: 16px;
		}
		
		.card .content span:last-child {
			font-size: 14px;
			color: #18cfab;
			text-align: center;
			font-weight: 700;
		}
		
		@media screen and (max-width: 768px) {
			.card {
				width: 50%;
			}
			.card .content {
				bottom: 0;
			}
		}
		
		@media screen and (max-width: 480px) {
			.card {
				width: 100%;
			}
		}
		</style>
	</asp:Content>