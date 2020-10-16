<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSelectedPics.ascx.cs"
    Inherits="Decili.UserControls.UCSelectedNews" %>
<div class="layerslider-wrapper box hidden-xs" >
    <div class="bannercontainer banner-boxed" style="padding: 0px; margin: 0px 0px 0px;">
        <div id="sliderlayer" class="rev_slider boxedbanner" style="width: 580px;
            height: 413px;">
            
            <ul>
                <li data-link="https://www.Decili.ir" data-masterspeed="300" data-transition="random"
                    data-slotamount="7" data-thumb="/images/slide_image.jpg">
                    <img src="/images/slide_image.jpg" />
                    
                    <div class="caption  sfr easeInExpo   easeInExpo 
											" data-x="0" data-y="0" data-speed="300" data-start="0"
                        data-easing="easeOutExpo">
                        <img src="/Files/Pics/sl1.jpg" alt="data/slide-1x-respino.jpg">
                    </div>
                </li>
                <li data-link="https://www.Decili.ir" data-masterspeed="300" data-transition="random"
                    data-slotamount="7" data-thumb="/images/slide_image.jpg">
                    <img src="/images/slide_image.jpg" />
                    <div class="caption  sfr easeInExpo   easeInExpo" data-x="0" data-y="0" data-speed="300" data-start="0"
                        data-easing="easeOutExpo">
                        <img src="/Files/Pics/sl2.jpg" alt="data/slide-1x-respino.jpg">
                    </div>
                </li>
                <li data-link="https://www.Decili.ir" data-masterspeed="300" data-transition="random"
                    data-slotamount="7" data-thumb="/images/slide_image.jpg">
                    <img src="/images/slide_image.jpg" />
                    
                    <div class="caption  sfr 
											easeInExpo   easeInExpo 
											" data-x="0" data-y="0" data-speed="300" data-start="0"
                        data-easing="easeOutExpo">
                        <img src="/Files/Pics/sl3.jpg" alt="data/slide-1x-respino.jpg">
                    </div>
                </li>
                <li data-link="https://www.Decili.ir" data-masterspeed="300" data-transition="random"
                    data-slotamount="7" data-thumb="/images/slide_image.jpg">
                    <img src="/images/slide_image.jpg" />
                    
                    <div class="caption  sfr 
											easeInExpo   easeInExpo 
											" data-x="0" data-y="0" data-speed="300" data-start="0"
                        data-easing="easeOutExpo">
                        <img src="/Files/Pics/sl4.jpg" alt="data/slide-1x-respino.jpg">
                    </div>
                </li>
                <li data-link="https://www.Decili.ir" data-masterspeed="300" data-transition="random"
                    data-slotamount="7" data-thumb="/images/slide_image.jpg">
                    <img src="/images/slide_image.jpg" />
                    
                    <div class="caption  sfr 
											easeInExpo   easeInExpo 
											" data-x="0" data-y="0" data-speed="300" data-start="0"
                        data-easing="easeOutExpo">
                        <img src="/Files/Pics/sl5.jpg" alt="data/slide-1x-respino.jpg">
                    </div>
                </li>
            </ul>
            <div class="tp-bannertimer tp-top">
            </div>
        </div>
    </div>
    
</div>
<script type="text/javascript">

    var tpj = jQuery;


    tpj('#sliderlayer').revolution(
						{
						    delay: 4000,
						    startheight: 413,
						    startwidth: 580,
						    hideThumbs: 200,
						    thumbWidth: 100,
						    thumbHeight: 50,
						    thumbAmount: 5,
						    navigationType: "none",
						    navigationArrows: "verticalcentered",
						    navigationStyle: "round",

						    navOffsetHorizontal: 0,
						    navOffsetVertical: 20,

						    touchenabled: "on",
						    onHoverStop: "on",
						    shuffle: "off",
						    stopAtSlide: -1,
						    stopAfterLoops: -1,

						    hideCaptionAtLimit: 0,
						    hideAllCaptionAtLilmit: 0,
						    hideSliderAtLimit: 0,
						    fullWidth: "on",
						    shadow: 0

						});



				

</script>
