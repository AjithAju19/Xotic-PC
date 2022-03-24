<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
      <div class="item active">
        <img src= "icons/game-ready.jpg" alt="Los Angeles" style="width:100%;">
      
          <div class="carousel-caption">
              <p><a class ="btn btn-lg btn-primary" href="#" role="button">Buy now</a></p>
          </div>
      
      
      </div>

      <div class="item">
        <img src="icons/geforce-max-q-fb-evens-3c33-D@2x.jpg" alt="Chicago" style="width:100%;">
      </div>
    
      <div class="item">
        <img src="icons/geforce-rtx-20-series-laptop.jpg" alt="New york" style="width:100%;">
      </div>

        <div class="item">
        <img src= "icons/geforce.jpg" alt="New york" style="width:100%;">
      </div>

        <div class="item">
        <img src="icons/nvidia-rtx-games.jpg" alt="New york" style="width:100%;">
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>

</div>

    <br />

    <!--Middle content starts -->
    <div class ="container center">
        <div class="row">
            <div class="col-lg-4">
                <img  src="icons/maxresdefault-1_1024x1024.jpg" alt="thumb" width="140" height="140" />
            
                <h4>MOBILE 3000 SERIES RTX AMPERE</h4>
                <p>GeForce RTX™ 30 Series GPUs power the world’s fastest laptops for gamers and creators. They’re built with the award-winning Ampere—NVIDIA’s...</p>
                <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p>
            
            </div>

            <div class="col-lg-4">
                <img  src="icons/radeon_1024x1024.png" alt="thumb" width="140" height="140" />
            
                <h4>PERFORMANCE TO RULE YOUR GAME AND RX 6000 Series</h4>
                <p>Introducing the AMD Radeon™ RX 6000 Series graphics cards, featuring the breakthrough AMD RDNA™ 2 architecture, engineered to deliver powerhouse...</p>
                <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p>
            
            </div>

            <div class="col-lg-4">
                <img  src="icons/5000series_1024x1024.png" alt="thumb" width="140" height="140" />
            
                <h4>BE UNSTOPPABLE WITH NEW AMD RYZEN 5000 SERIES</h4>
                <p>Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD RYZEN 5000 Series processors deliver the ultimate in high...</p>
                <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p>
            
            </div>

            <div class="col-lg-4">
                <img  src="icons/desktop3000_1024x1024.png" alt="thumb" width="140" height="140" />
            
                <h4>GEOFORCE RTX 30 SERIES PCS THE ULTIMATE PLAY</h4>
                <p>PCs equipped with GeForce RTX™ 30 Series GPUs deliver the ultimate performance for gamers and creators. They’re powered by Ampere—NVIDIA’s...</p>
                <p><a class="btn btn-default" href="#" role="button">Read More &raquo;</a></p>
            
            </div>
        </div>
    </div>

    <!--Middle Content closes-->



</asp:Content>

