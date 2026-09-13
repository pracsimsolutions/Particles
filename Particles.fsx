<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="tree">
<node f="42"><name>Particles</name>
 <node f="40"><name></name></node>
 <node f="42"><name>installdata</name>
  <node f="40"><name></name></node>
  <node f="42" dt="2"><name>add_library</name><data>MAIN:/project/library</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>fluid</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42"><name>Particles</name>
      <node f="40"><name></name></node>
      <node f="10000062" dt="4"><name>ParticleSystem</name><data>
       <node f="40"><name></name></node>
       <node f="42"><name>classes</name>
        <node f="40"><name></name></node>
        <node f="42" dt="3"><name>Particles::ParticleSystem</name><data><coupling>/installdata/add_library/Particles/data/Particles/ParticleSystem</coupling></data></node>
       </node>
       <node f="42"><name>superclasses</name>
        <node f="40"><name></name></node>
        <node f="42" dt="3"><name>FlexSimEventHandler</name><data><coupling>null</coupling></data></node>
       </node>
       <node f="42"><name>variables</name>
        <node f="80000040"><name></name></node>
        <node f="42" dt="1"><name>liveCap</name><data>0000000041086a00</data></node>
        <node f="42" dt="1"><name>showPlanes</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>showArrows</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>arrowSize</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>lod</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>lodStart</name><data>0000000040390000</data></node>
        <node f="42" dt="1"><name>lodMin</name><data>47ae147b3fb47ae1</data></node>
        <node f="42" dt="1"><name>statEmitterCount</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statTotalLive</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statBuildMs</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statDrawMs</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>behaviour</name>
        <node f="40"><name></name></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>flexScriptInterface</name><data>Particles.System</data></node>
        </node>
       </node>
       <node f="42"><name>visual</name>
        <node f="40"><name></name></node>
        <node f="42"><name>color</name>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>red</name><data>9999999a3fd99999</data></node>
         <node f="42" dt="1"><name>green</name><data>9999999a3fe99999</data></node>
         <node f="42" dt="1"><name>blue</name><data>00000000400c0000</data></node>
        </node>
        <node f="42" dt="2"><name>shape</name><data></data></node>
        <node f="42" dt="1"><name>shapeindex</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>picture</name><data>bitmaps\ParticleSystem.png</data></node>
        <node f="42" dt="2"><name>imageobject</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexobject</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>imagebase</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexbase</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>drawflags</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>spatial</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>spatialsz</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>spatialrx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialry</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialrz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>centroid</name><data>000000003ff00000</data></node>
       </node>
       <node f="42" dt="2"><name>windowtitle</name><data>ParticleSystem</data></node>
      </data></node>
      <node f="10000042" dt="4"><name>ParticleEmitter</name><data>
       <node f="40"><name></name></node>
       <node f="42"><name>classes</name>
        <node f="40"><name></name></node>
        <node f="42" dt="3"><name>Particles::ParticleEmitter</name><data><coupling>/installdata/add_library/Particles/data/Particles/ParticleEmitter</coupling></data></node>
       </node>
       <node f="42"><name>variables</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>rate</name><data>0000000040690000</data></node>
        <node f="42" dt="1"><name>lifetime</name><data>0000000040000000</data></node>
        <node f="42" dt="1"><name>lifetimeJitter</name><data>9999999a3fd99999</data></node>
        <node f="42" dt="1"><name>startTimeVal</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>stopTimeFieldVal</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>prewarm</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>shapeField</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>directionField</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040390000</data></node>
        <node f="42" dt="1"><name>speed</name><data>0000000040000000</data></node>
        <node f="42" dt="1"><name>speedJitter</name><data>000000003fe00000</data></node>
        <node f="42" dt="1"><name>drag</name><data>0000000000000000</data></node>
        <node f="42" dt="7"><name>gravity</name><data/>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>x</name><data>0000000000000000</data></node>
         <node f="42" dt="1"><name>y</name><data>0000000000000000</data></node>
         <node f="42" dt="1"><name>z</name><data>00000000c0000000</data></node>
         <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::Vec3Property</data>
          <node f="40"><name></name></node></node>
        </node>
        <node f="42" dt="7"><name>wind</name><data/>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>x</name><data>0000000000000000</data></node>
         <node f="42" dt="1"><name>y</name><data>0000000000000000</data></node>
         <node f="42" dt="1"><name>z</name><data>0000000000000000</data></node>
         <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::Vec3Property</data>
          <node f="40"><name></name></node></node>
        </node>
        <node f="42" dt="1"><name>swirlAmp</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>swirlFreq</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>sizeStart</name><data>9999999a3fc99999</data></node>
        <node f="42" dt="1"><name>sizeEnd</name><data>9999999a3fa99999</data></node>
        <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>seedField</name><data>0000000040c81c80</data></node>
        <node f="42" dt="1"><name>disabled</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statLiveCount</name><data>0000000000000000</data></node>
        <node f="42" dt="7"><name>colorStart</name><data/>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>r</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>g</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>b</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>a</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
          <node f="40"><name></name></node></node>
        </node>
        <node f="42" dt="7"><name>colorEnd</name><data/>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>r</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>g</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>b</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>a</name><data>0000000000000000</data></node>
         <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
          <node f="40"><name></name></node></node>
        </node>
       </node>
       <node f="42"><name>behaviour</name>
        <node f="40"><name></name></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>flexScriptInterface</name><data>Particles.Emitter</data></node>
         <node f="442" dt="2"><name>OnCreate</name><data>// Auto-create the singleton ParticleSystem on first emitter drop.
if (model().find("ParticleSystem") == NULL) {
	treenode sys = createinstance(library().find("?ParticleSystem"), model());
	sys.name = "ParticleSystem";
}</data></node>
         <node f="1000042" dt="2"><name>OnDraw</name><data>dll:"module:Particles" func:"ParticleEmitter_OnDraw"</data></node>
         <node f="42"><name>configs</name>
          <node f="40"><name></name></node>
          <node f="42" dt="4"><name>Emitter</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\ParticleEmitter.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Emitter</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>rate</name><data>0000000040690000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>0000000040000000</data></node>
            <node f="42" dt="1"><name>lifetimeJitter</name><data>9999999a3fd99999</data></node>
            <node f="42" dt="1"><name>shapeField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040390000</data></node>
            <node f="42" dt="1"><name>speed</name><data>0000000040000000</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>000000003fe00000</data></node>
            <node f="42" dt="7"><name>gravity</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>x</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>y</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>z</name><data>00000000c0000000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::Vec3Property</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="1"><name>drag</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>sizeStart</name><data>9999999a3fc99999</data></node>
            <node f="42" dt="1"><name>sizeEnd</name><data>9999999a3fa99999</data></node>
            <node f="42" dt="7"><name>colorStart</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>g</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>b</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>a</name><data>000000003ff00000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="7"><name>colorEnd</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>g</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>b</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>a</name><data>0000000000000000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
           </node>
          </node>
          <node f="42" dt="4"><name>Smoke</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\Smoke.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Smoke</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>rate</name><data>00000000404e0000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>0000000040080000</data></node>
            <node f="42" dt="1"><name>speed</name><data>9999999a3fe99999</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>333333333fd33333</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040320000</data></node>
            <node f="42" dt="7"><name>gravity</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>x</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>y</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>z</name><data>9999999a3fd99999</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::Vec3Property</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="1"><name>drag</name><data>333333333fe33333</data></node>
            <node f="42" dt="1"><name>sizeStart</name><data>333333333fd33333</data></node>
            <node f="42" dt="1"><name>sizeEnd</name><data>333333333ff33333</data></node>
            <node f="42" dt="7"><name>colorStart</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>000000003fe80000</data></node>
             <node f="42" dt="1"><name>g</name><data>000000003fe80000</data></node>
             <node f="42" dt="1"><name>b</name><data>8f5c28f63fe8f5c2</data></node>
             <node f="42" dt="1"><name>a</name><data>000000003fe00000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="7"><name>colorEnd</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>000000003fe00000</data></node>
             <node f="42" dt="1"><name>g</name><data>000000003fe00000</data></node>
             <node f="42" dt="1"><name>b</name><data>9999999a3fe19999</data></node>
             <node f="42" dt="1"><name>a</name><data>0000000000000000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
           </node>
          </node>
          <node f="42" dt="4"><name>Sparks</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\Sparks.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Sparks</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>rate</name><data>000000004062c000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>speed</name><data>0000000040100000</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>0000000040000000</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040418000</data></node>
            <node f="42" dt="7"><name>gravity</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>x</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>y</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>z</name><data>00000000c0180000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::Vec3Property</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="1"><name>sizeStart</name><data>9999999a3fa99999</data></node>
            <node f="42" dt="1"><name>sizeEnd</name><data>47ae147b3f947ae1</data></node>
            <node f="42" dt="7"><name>colorStart</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>g</name><data>cccccccd3feccccc</data></node>
             <node f="42" dt="1"><name>b</name><data>9999999a3fd99999</data></node>
             <node f="42" dt="1"><name>a</name><data>000000003ff00000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="7"><name>colorEnd</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>g</name><data>333333333fd33333</data></node>
             <node f="42" dt="1"><name>b</name><data>9999999a3fa99999</data></node>
             <node f="42" dt="1"><name>a</name><data>0000000000000000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
           </node>
          </node>
          <node f="42" dt="4"><name>Fountain</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\Fountain.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Fountain</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>rate</name><data>000000004072c000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>0000000040040000</data></node>
            <node f="42" dt="1"><name>speed</name><data>0000000040100000</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>333333333fe33333</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040280000</data></node>
            <node f="42" dt="7"><name>gravity</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>x</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>y</name><data>0000000000000000</data></node>
             <node f="42" dt="1"><name>z</name><data>00000000c0080000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::Vec3Property</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="1"><name>sizeStart</name><data>47ae147b3fb47ae1</data></node>
            <node f="42" dt="7"><name>colorStart</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>9999999a3fd99999</data></node>
             <node f="42" dt="1"><name>g</name><data>666666663fe66666</data></node>
             <node f="42" dt="1"><name>b</name><data>000000003ff00000</data></node>
             <node f="42" dt="1"><name>a</name><data>000000003ff00000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
            <node f="42" dt="7"><name>colorEnd</name><data/>
             <node f="40"><name></name></node>
             <node f="42" dt="1"><name>r</name><data>9999999a3fb99999</data></node>
             <node f="42" dt="1"><name>g</name><data>333333333fd33333</data></node>
             <node f="42" dt="1"><name>b</name><data>cccccccd3feccccc</data></node>
             <node f="42" dt="1"><name>a</name><data>0000000000000000</data></node>
             <node f="42" dt="2"><name>sdt::attributetree</name><data>Particles::ColorProperty</data>
              <node f="40"><name></name></node></node>
            </node>
           </node>
          </node>
         </node>
        </node>
        <node f="42"><name>properties</name>
         <node f="40"><name></name></node>
         <node f="42" dt="4"><name>EndColor</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>MAIN:/project/library/FlexSimEventHandler&gt;behaviour/ColorProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="1"><name>noFilter</name><data>000000003ff00000</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
           <node f="42" dt="1"><name>namespaceType</name><data>0000000040000000</data></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/colorEnd</data></node>
          </node>
         </data></node>
         <node f="42" dt="4"><name>StartColor</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>MAIN:/project/library/FlexSimEventHandler&gt;behaviour/ColorProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="1"><name>noFilter</name><data>000000003ff00000</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
           <node f="42" dt="1"><name>namespaceType</name><data>0000000040000000</data></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/colorStart</data></node>
          </node>
         </data></node>
         <node f="42" dt="4"><name>Rate</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/rate</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>StartTime</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitUniversalProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/startTimeVal</data></node>
           <node f="42" dt="2"><name>unitType</name><data>time</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>StopTime</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitUniversalProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/stopTimeFieldVal</data></node>
           <node f="42" dt="2"><name>unitType</name><data>time</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>Prewarm</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitUniversalProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/prewarm</data></node>
           <node f="42" dt="2"><name>unitType</name><data>time</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>Lifetime</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitUniversalProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/lifetime</data></node>
           <node f="42" dt="2"><name>unitType</name><data>time</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>LifetimeJitter</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitUniversalProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/lifetimeJitter</data></node>
           <node f="42" dt="2"><name>unitType</name><data>time</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>ConeHalfAngle</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/coneHalfAngleDeg</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>Speed</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitValueProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/speed</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
           <node f="42" dt="2"><name>unitType</name><data>speed</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>SpeedJitter</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/UnitValueProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/speedJitter</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
           <node f="42" dt="2"><name>unitType</name><data>speed</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>Drag</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/drag</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>SwirlAmp</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/swirlAmp</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>SwirlFreq</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/swirlFreq</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>SizeStart</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/sizeStart</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>SizeEnd</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/sizeEnd</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>Seed</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/NumberProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/seedField</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>ShapeField</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/ComboProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/shapeField</data></node>
           <node f="42"><name>options</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>Point</name><data>0000000000000000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Line</name><data>000000003ff00000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Disk</name><data>0000000040000000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Plane</name><data>0000000040080000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Box</name><data>0000000040100000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Sphere</name><data>0000000040140000</data>
             <node f="40"><name></name></node></node>
           </node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>DirectionField</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/ComboProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/directionField</data></node>
           <node f="42"><name>options</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>Aimed</name><data>0000000000000000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Omni</name><data>000000003ff00000</data>
             <node f="40"><name></name></node></node>
           </node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>StyleField</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/ComboProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/styleField</data></node>
           <node f="42"><name>options</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>Point</name><data>0000000000000000</data>
             <node f="40"><name></name></node></node>
            <node f="42" dt="1"><name>Sprite</name><data>000000003ff00000</data>
             <node f="40"><name></name></node></node>
           </node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
         <node f="42" dt="4"><name>Gravity</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/Vec3Property</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
           <node f="42" dt="1"><name>namespaceType</name><data>0000000040000000</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node>
           <node f="442" dt="2"><name>getValue</name><data>return param(1).as(Particles.Emitter).gravity;
</data></node>
           <node f="442" dt="2"><name>setValue</name><data>Vec3 toLoc = param(2);
Object obj = param(1);
obj.as(Particles.Emitter).gravity = toLoc;</data></node>
          </node>
         </data></node>
         <node f="42" dt="4"><name>Wind</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/Vec3Property</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
           <node f="42" dt="1"><name>namespaceType</name><data>0000000040000000</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node>
           <node f="442" dt="2"><name>getValue</name><data>return param(1).as(Particles.Emitter).wind;
</data></node>
           <node f="442" dt="2"><name>setValue</name><data>Vec3 toLoc = param(2);
Object obj = param(1);
obj.as(Particles.Emitter).wind = toLoc;</data></node>
          </node>
         </data></node>
         <node f="42" dt="4"><name>Disabled</name><data>
          <node f="40"><name></name></node>
          <node f="42"><name>superclasses</name>
           <node f="40"><name></name></node>
           <node f="42" dt="3"><name>/FlexSimEventHandler&gt;behaviour/CheckboxProperty</name><data><coupling>null</coupling></data></node>
          </node>
          <node f="42"><name>variables</name>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>varPath</name><data>&gt;variables/disabled</data></node>
           <node f="42" dt="2"><name>category</name><data>Particles&gt;Emitter</data></node>
          </node>
          <node f="42"><name>eventfunctions</name>
           <node f="40"><name></name></node></node>
         </data></node>
        </node>
       </node>
       <node f="42"><name>visual</name>
        <node f="40"><name></name></node>
        <node f="42"><name>color</name>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>red</name><data>9999999a3fb99999</data></node>
         <node f="42" dt="1"><name>green</name><data>6666666666e63f66</data></node>
         <node f="42" dt="1"><name>blue</name><data>000000003ff00000</data></node>
        </node>
        <node f="42" dt="2"><name>shape</name><data></data></node>
        <node f="42" dt="1"><name>shapeindex</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>picture</name><data>bitmaps\ParticleEmitter.png</data></node>
        <node f="42" dt="2"><name>imageobject</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexobject</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>imagebase</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexbase</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>drawflags</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>special</name>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>title</name><data>Particle Emitter</data></node>
        <node f="42" dt="2"><name>description</name><data>Emits particles at draw time as an analytic function of model time. Drop one or more; the Particle System is created automatically.</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/standardviews/modelingutilities/QuickerProperties</data></node>
       </node>
       <node f="42"><name>spatial</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000003fd00000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>000000003fd00000</data></node>
        <node f="42" dt="1"><name>spatialsz</name><data>000000003fd00000</data></node>
        <node f="42" dt="1"><name>spatialrx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialry</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialrz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>centroid</name><data>000000003ff00000</data></node>
       </node>
       <node f="42" dt="2"><name>windowtitle</name><data>ParticleEmitter</data></node>
      </data></node>
     </node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_modules</name><data>VIEW:/modules</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42"><name>after</name></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42"><name>Particles</name>
      <node f="40"><name></name></node>
      <node f="42"><name>LibraryGroup</name>
       <node f="40"><name></name></node>
       <node f="42" dt="4"><name>Emitter</name><data>
        <node f="40"><name></name></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Emitter</data></node>
        <node f="4000000042" dt="2"><name>tooltip</name><data>An object that emits particles</data></node>
        <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\ParticleEmitter.png</data>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name></name><data>bitmaps\popOut.png</data></node>
        </node>
        <node f="42" dt="2"><name>popOutChoices</name><data>MAIN:/project/library/Particles/ParticleEmitter&gt;behaviour/eventfunctions/configs</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>customDropScript</name><data>treenode template = param(1);
treenode dragTo = param(2);
double dropX = param(3);
double dropY = param(4);
double dropZ = param(5);
treenode view = param(6);

treenode obj = dropuserlibraryobject(node("~",template), dragTo, dropX, dropY, dropZ, view);

//Apply any changes specified by the subnodes of the template shape
for(int j = 1; j &lt;= template.subnodes.length; j++)
{
	treenode copyFrom = template.subnodes[j];
	treenode copyTo = obj.find("&gt;" + copyFrom.name);
	if (objectexists(copyTo)){
		for (int k = 1; k &lt;= copyFrom.subnodes.length; k++){
			if (copyTo.subnodes[copyFrom.subnodes[k].name]){
				createcopy(copyFrom.subnodes[k], copyTo.subnodes[copyFrom.subnodes[k].name], 1, 0, 0, 1);
			}
			else {
				createcopy(copyFrom.subnodes[k], copyTo.subnodes[copyFrom.subnodes[k].name], 1, 0, 0, 0);
			}
		}
	}
}
rebindobjectattributes(obj);
return obj;
</data></node>
        </node>
       </data></node>
      </node>
      <node f="42"><name>Pages</name>
       <node f="40"><name></name></node>
       <node f="42" dt="4"><name>ParticleSystemProperties</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="3"><name>viewfocus</name><data><coupling>null</coupling></data></node>
        <node f="42" dt="3"><name>objectfocus</name><data><coupling>null</coupling></data></node>
        <node f="42" dt="1"><name>viewwindowopen</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040100000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040666000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004057c000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000004075e000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000406cc000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Particle System Properties</data></node>
        <node f="442" dt="2"><name>OnOpen</name><data>treenode tabcontrol = node("/tabcontrol",c);
iterate(1, content(tabcontrol), 1){
  if (objectexists(node("&gt;PageOnOpen",rank(tabcontrol,count))))
     nodefunction(node("&gt;PageOnOpen",rank(tabcontrol,count)));
}

repaintview(c);</data></node>
        <node f="42" dt="2"><name>OnPreOpen</name><data>c.name = "Particle System Properties";
standardpreopen(c);
</data>
         <node f="40"><name></name></node></node>
        <node f="42" dt="2"><name>OnClose</name><data></data></node>
        <node f="442" dt="2"><name>OnApply</name><data>treenode tabcontrol = node("../tabcontrol",c);
iterate(1, content(tabcontrol), 1){
  if (objectexists(node("&gt;PageOnApply",rank(tabcontrol,count))))
     nodefunction(node("&gt;PageOnApply",rank(tabcontrol,count)));
}
applylinks(c);
repaintall();</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node></node>
        <node f="42" dt="2"><name>helptopic</name><data>Particles::ParticleSystemPanel</data></node>
       </data>
        <node f="40"><name></name></node>
        <node f="42" dt="4"><name>Show Planes</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405a4000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>000000004062c000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
         <node f="42" dt="2"><name>tooltip</name><data>Show each emitter's region outline (the wireframe emission shape).</data></node>
         <node f="42" dt="2"><name>coldlink</name><data>@&gt;objectfocus+&gt;variables/showPlanes</data></node>
        </data></node>
        <node f="42" dt="4"><name>Show Arrows</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405a4000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>00000000403b0000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>000000004062c000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
         <node f="42" dt="2"><name>tooltip</name><data>Show each emitter's aim-direction arrow handle.</data></node>
         <node f="42" dt="2"><name>coldlink</name><data>@&gt;objectfocus+&gt;variables/showArrows</data></node>
        </data></node>
        <node f="42" dt="4"><name>ArrowSize</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>00000000404b0000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>0000000040550000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
         <node f="4000000042" dt="2"><name>windowtitle</name><data>Arrow Size</data></node>
        </data></node>
        <node f="42" dt="4"><name>EditArrowSize</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
         <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UnitValueEdit</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>0000000040498000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>000000004056c000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
         <node f="42" dt="1"><name>alignrightmargin</name><data>00000000403e0000</data></node>
         <node f="42"><name>variables</name>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name>valueType</name><data>length</data></node>
          <node f="42" dt="1"><name>rangemin</name><data>0000000000000000</data></node>
         </node>
         <node f="42" dt="2"><name>objectfocus</name><data>@&gt;objectfocus+&gt;variables/arrowSize</data></node>
         <node f="42" dt="2"><name>tooltip</name><data>World size of the aim-arrow handles (display only; no effect on particles).</data></node>
        </data></node>
        <node f="42" dt="4"><name>Use Level of Detail</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405a4000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>000000004052c000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>000000004062c000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
         <node f="42" dt="2"><name>tooltip</name><data>Far emitters emit fewer particles to cut draw cost.</data></node>
         <node f="42" dt="2"><name>coldlink</name><data>@&gt;objectfocus+&gt;variables/lod</data></node>
        </data></node>
        <node f="42" dt="4"><name>LODStart</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>0000000040598000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>0000000040550000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
         <node f="4000000042" dt="2"><name>windowtitle</name><data>LOD Start</data></node>
        </data></node>
        <node f="42" dt="4"><name>EditLODStart</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
         <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UnitValueEdit</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>000000004058c000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>000000004058c000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
         <node f="42" dt="1"><name>alignrightmargin</name><data>00000000403e0000</data></node>
         <node f="42"><name>variables</name>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name>valueType</name><data>length</data></node>
          <node f="42" dt="1"><name>rangemin</name><data>0000000000000000</data></node>
         </node>
         <node f="42" dt="2"><name>objectfocus</name><data>@&gt;objectfocus+&gt;variables/lodStart</data></node>
         <node f="42" dt="2"><name>tooltip</name><data>Distance within which emitters keep full detail; thinning begins past it.</data></node>
        </data></node>
        <node f="42" dt="4"><name>LODMin</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>00000000405f8000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>0000000040550000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
         <node f="4000000042" dt="2"><name>windowtitle</name><data>LOD Min</data></node>
        </data></node>
        <node f="42" dt="4"><name>EditLODMin</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
         <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UnitValueEdit</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>00000000405ec000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>000000004058c000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
         <node f="42" dt="1"><name>alignrightmargin</name><data>00000000403e0000</data></node>
         <node f="42"><name>variables</name>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name>valueType</name><data>length</data></node>
          <node f="42" dt="1"><name>rangemin</name><data>0000000000000000</data></node>
         </node>
         <node f="42" dt="2"><name>objectfocus</name><data>@&gt;objectfocus+&gt;variables/lodMin</data></node>
         <node f="42" dt="2"><name>tooltip</name><data>Lowest the LOD thinning can go (0 to 1): how sparse a far emitter may get.</data></node>
        </data></node>
        <node f="42" dt="4"><name>BottomButtons</name><data>
         <node f="40"><name>object</name></node>
         <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
         <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
         <node f="42" dt="1"><name>spatialy</name><data>00000000403c0000</data></node>
         <node f="42" dt="1"><name>spatialsx</name><data>0000000040755000</data></node>
         <node f="42" dt="1"><name>spatialsy</name><data>0000000040360000</data></node>
         <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
         <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/BottomButtons</data></node>
         <node f="42"><name>variables</name>
          <node f="40"><name></name></node>
          <node f="42"><name>deleteButtons</name>
           <node f="40"><name></name></node>
           <node f="42"><name>Tree</name></node>
           <node f="42"><name>Prev</name></node>
           <node f="42"><name>Next</name></node>
           <node f="42"><name>Center in View</name></node>
          </node>
         </node>
        </data></node>
       </node>
      </node>
     </node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_list</name><data>VIEW:/standardviews/modelingutilities/LibraryIconGrid/GroupIconGrid&gt;variables/visibilityLists/base/list</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>Fluid</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42" dt="4"><name>Particles</name><data>
      <node f="40"><name></name></node>
      <node f="42" dt="2"><name>viewfocus</name><data>VIEW:/modules/Particles/LibraryGroup</data></node>
      <node f="42" dt="1"><name>picturealignleft</name><data>0000000040360000</data></node>
      <node f="42" dt="1"><name>expanded</name><data>000000003ff00000</data></node>
      <node f="4000000042" dt="2"><name>windowtitle</name><data>Particles</data></node>
     </data>
      <node f="40"><name></name></node></node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_propertiesPanels</name><data>VIEW:/standardviews/modelingutilities/QuickProperties&gt;variables/propertiesPanels</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>ParticleEmitter</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>Triggers</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42" dt="4"><name>ParticleEmitter</name><data>
      <node f="40"><name>object</name></node>
      <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040180000</data>
       <node f="40"><name></name></node></node>
      <node f="42" dt="2"><name>guifocusclass</name><data>../../..&gt;variables/QuickPropertiesPanel</data></node>
      <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
      <node f="42" dt="1"><name>spatialy</name><data>0000000000000000</data></node>
      <node f="42" dt="1"><name>spatialsx</name><data>0000000040634000</data></node>
      <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
      <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
      <node f="42"><name>variables</name>
       <node f="40"><name></name></node>
       <node f="42"><name>propTableQueryTree</name>
        <node f="40"><name></name></node>
        <node f="42"><name>SELECT</name>
         <node f="40"><name></name></node>
         <node f="42"><name>Color</name></node>
         <node f="42"><name>CorridorType</name></node>
         <node f="42"><name>Geometry</name></node>
         <node f="42"><name>Bulge</name></node>
        </node>
        <node f="42"><name>FROM</name>
         <node f="40"><name></name></node>
         <node f="42"><name>Objects()</name></node>
        </node>
        <node f="42"><name>WHERE</name>
         <node f="40"><name></name></node>
         <node f="42"><name>IN</name>
          <node f="40"><name></name></node>
          <node f="42"><name>"RouteGraph::Corridor"</name></node>
          <node f="42"><name>Classes</name></node>
         </node>
        </node>
        <node f="42"><name>ORDER BY</name></node>
       </node>
       <node f="42" dt="2"><name>helptopic</name><data>Particles::Emitter</data></node>
      </node>
     </data>
      <node f="40"><name></name></node>
      <node f="42" dt="4"><name>ParticleEmitter</name><data>
       <node f="40"><name>object</name></node>
       <node f="42" dt="3"><name>objectfocus</name><data><coupling>null</coupling></data></node>
       <node f="42" dt="3"><name>viewfocus</name><data><coupling>null</coupling></data></node>
       <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040598000</data></node>
       <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
       <node f="42" dt="1"><name>spatialy</name><data>0000000040350000</data></node>
       <node f="42" dt="1"><name>spatialsx</name><data>000000004062c000</data></node>
       <node f="42" dt="1"><name>spatialsy</name><data>000000004083b000</data></node>
       <node f="42"><name>variables</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>isExpanded</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>showRequirements</name><data>0000000000000000</data>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>selObj</name><data>return objectexists(param(1)) &amp;&amp; isclasstype(param(1), "Particles::ParticleEmitter");</data></node>
         <node f="442" dt="2"><name>docType</name><data>string docType = gets(documentwindow(param(1)));
return docType == "3D" || docType == "Tree";</data></node>
         <node f="42" dt="1"><name>editMode</name><data>0000000000000000</data></node>
        </node>
       </node>
       <node f="42" dt="2"><name>undohistory</name><data>..&gt;viewfocus+</data></node>
       <node f="42"><name>eventfunctions</name>
        <node f="40"><name></name></node>
        <node f="442" dt="2"><name>onSelObjChange</name><data>nodepoint(objectfocus(c), param(1));
nodepoint(viewfocus(c), activedocumentnode());
applylinks(c, 1);
</data></node>
        <node f="442" dt="2"><name>onPropsApply</name><data>applylinks(c, 1);</data></node>
        <node f="442" dt="2"><name>onExpand</name><data>if (param(1)) {// expanded
	applylinks(c, 1);
}
</data></node>
        <node f="42" dt="2"><name>OnUndo</name><data>applylinks(c, 1);
function_s(node("/RouteGraphNetwork", model()), "refreshMesh");
</data></node>
        <node f="42" dt="2"><name>coldlinkx</name><data>if (!eventdata &amp;&amp; eventcode == APPLY_LINKS_ON_OPEN) {
	function_s(node("/ChooseType", c), "refreshList");
	function_s(node("/ChooseAccumType", c), "refreshList");
}</data></node>
       </node>
       <node f="42" dt="2"><name>tooltip</name><data></data></node>
       <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
       <node f="4000000042" dt="2"><name>windowtitle</name><data>Emitter</data></node>
       <node f="42" dt="1"><name>beveltype</name><data>0000000000000000</data></node>
      </data>
       <node f="40"><name></name></node>
       <node f="42" dt="4"><name>Disabled</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405a4000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Checkbox</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>itemcurrent</name><data>000000003ff00000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Check to Disable the Particle Emitter</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>Disabled</data></node>
        </node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Disabled</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>StartColor</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000403e0000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000004052c000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Start Color</data></node>
       </data></node>
       <node f="42" dt="4"><name>StartColorPanel</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040598000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Color</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000403b0000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040534000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040080000</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Particle color and opacity at birth.</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>StartColor</data></node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../StartColor</data></node>
        </node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>onApply</name><data>treenode focus = c.find("..&gt;objectfocus+");
createundorecord(c, focus, UNDO_CUSTOM);
if (switch_selected(focus, -1)) {
	forobjecttreeunder(model()) {
		if (switch_selected(a, -1) &amp;&amp; a != focus)
			createundorecord(c, a, UNDO_CUSTOM);
	}
}
</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>EndColor</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000404b0000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000004052c000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>End Color</data></node>
       </data></node>
       <node f="42" dt="4"><name>EndColorPanel</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040598000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Color</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040498000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040534000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040080000</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Color and opacity each particle fades to by the end of its life.</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>EndColor</data></node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../EndColor</data></node>
        </node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>onApply</name><data>treenode focus = c.find("..&gt;objectfocus+");
createundorecord(c, focus, UNDO_CUSTOM);
if (switch_selected(focus, -1)) {
	forobjecttreeunder(model()) {
		if (switch_selected(a, -1) &amp;&amp; a != focus)
			createundorecord(c, a, UNDO_CUSTOM);
	}
}
</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Generative Rate</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040538000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000004057c000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Generative Rate</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditGenerativeRate</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UnitValueEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/rate</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004052c000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000404e0000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040390000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>Rate</data></node>
         <node f="42" dt="2"><name>valueType</name><data>rate</data></node>
         <node f="42" dt="1"><name>isHotlink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>rateNumerator</name><data>p</data>
          <node f="40"><name></name></node>
          <node f="4000000042" dt="2"><name>single</name><data>particle</data></node>
          <node f="4000000042" dt="2"><name>plural</name><data>particles</data></node>
         </node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Particles emitted per second.</data></node>
       </data></node>
       <node f="42" dt="4"><name>StartTime</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040598000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Start Time</data></node>
       </data></node>
       <node f="42" dt="4"><name>StartTimeEdit</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004058c000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040783000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/startTimeVal</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Model time emission begins (0 = at run start). Accepts a number or FlexScript.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Start Time</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>time</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../StartTime</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>StartTime</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>StopTime</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000405f8000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Stop Time</data></node>
       </data></node>
       <node f="42" dt="4"><name>StopTimeEdit</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000405ec000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040783000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/stopTimeFieldVal</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Model time emission ends (0 = never stops). Accepts a number or FlexScript.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Stop Time</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>time</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../StopTime</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>StopTime</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Prewarm</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004062c000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Prewarm</data></node>
       </data></node>
       <node f="42" dt="4"><name>PrewarmEdit</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040626000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040783000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/prewarm</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Seconds pre-simulated at reset so the cloud starts full instead of empty.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Prewarm</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>time</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../Prewarm</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>Prewarm</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Speed</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004065c000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040534000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Speed</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditSpeed</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040656000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040568000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/speed</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Initial launch speed of each particle.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040380000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Speed</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>speed</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../Speed</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>Speed</data></node>
        </node>
        <node f="42" dt="1"><name>rangemin</name><data>0000000000000000</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>SpeedJitter</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004068c000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040534000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Speed Jitter</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditSpeedJitter</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040686000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040568000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/speedJitter</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Random +/- variation added to each particle's launch speed.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040380000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Speed Jitter</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>speed</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../SpeedJitter</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>SpeedJitter</data></node>
        </node>
        <node f="42" dt="1"><name>rangemin</name><data>0000000000000000</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Lifetime</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000406bc000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Lifetime</data></node>
       </data></node>
       <node f="42" dt="4"><name>LifeTimeEdit</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000406b4000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040783000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/lifetime</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>How long each particle lives before disappearing.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Prewarm</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>time</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../LifeTime</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>LifeTime</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>lifetimeJitter</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000406ec000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Lifetime Jitter</data></node>
       </data></node>
       <node f="42" dt="4"><name>LifetimeJitterEdit</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000406e4000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040783000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/lifetimeJitter</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Random extra lifetime added per particle.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Prewarm</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>time</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../LifetimeJitter</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>LifetimeJitter</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>ShapeField</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004070e000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040584000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Shape</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>EditShapeField</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405b4000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Options</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004070b000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040618000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>ShapeField</data></node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../ShapeField</data></node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Shape of the emission region (Point, Line, Disk, Plane, Box, Sphere).</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Direction</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040726000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040584000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Direction</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>EditDirection</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405b4000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Options</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040723000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040618000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>DirectionField</data></node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../DirectionField</data></node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Aimed launches in a cone along the arrow; Omni launches in all directions.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>ConeHalfAngle</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004073e000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040534000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Cone Half-Angle</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditConeHalfAngle</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004073b000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040568000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/coneHalfAngleDeg</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Half-angle of the Aimed launch cone, in degrees (wider = more spread). No effect on Omni.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040380000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Cone Half-Angle</data></node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../ConeHalfAngle</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>ConeHalfAngle</data></node>
        </node>
        <node f="42" dt="1"><name>rangemin</name><data>0000000000000000</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Style</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040756000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040584000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Style</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>EditStyle</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>00000000405b4000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Options</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040753000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040618000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>StyleField</data></node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../StyleField</data></node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Draw particles as soft dots or as the emitter's own image.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Vec3TopLabels</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040598000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Vec3TopLabels</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004076b000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000403e0000</data>
         <node f="40"><name></name></node></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040310000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040390000</data></node>
        <node f="42" dt="1"><name>beveltype</name><data>0000000000000000</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>StartLocation</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040598000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Vec3</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004077f000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data>
         <node f="40"><name></name></node></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040390000</data></node>
        <node f="42" dt="1"><name>beveltype</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>Gravity</data></node>
         <node f="4000000042" dt="2"><name>leftLabel</name><data>Gravity</data></node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Constant acceleration on every particle (e.g. Z = -9.8 for gravity).</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>onApply</name><data>applylinks(c.up, 1);</data></node>
        </node>
       </data></node>
       <node f="42" dt="4"><name>EndLocation</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040598000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Vec3</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040797000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data>
         <node f="40"><name></name></node></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040390000</data></node>
        <node f="42" dt="1"><name>beveltype</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>Wind</data></node>
         <node f="4000000042" dt="2"><name>leftLabel</name><data>Wind</data></node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Extra constant acceleration added on top of gravity.</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>onApply</name><data>applylinks(c.up, 1);</data></node>
        </node>
       </data></node>
       <node f="42" dt="4"><name>Drag</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407b2000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000004057c000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Drag</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditDrag</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UnitValueEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/drag</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Slows particles over time; higher values decay velocity faster.</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407af000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000404e0000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040390000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>Drag</data></node>
         <node f="42" dt="2"><name>valueType</name><data>rate</data></node>
         <node f="42" dt="1"><name>isHotlink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>rateNumerator</name><data>1</data>
          <node f="40"><name></name></node>
          <node f="4000000042" dt="2"><name>single</name><data>1</data></node>
          <node f="4000000042" dt="2"><name>plural</name><data>1</data></node>
         </node>
        </node>
       </data></node>
       <node f="42" dt="4"><name>SwirlAmp</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407ca000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>swirl Amplitude</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditswirlAmp</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407c7000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/swirlAmp</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Radius of a spiral wobble added to each particle's path (0 = none).</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Prewarm</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>length</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../SwirlAmp</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>SwirlAmp</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>SwirlFreq</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407e2000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000004057c000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Swirl Frequency</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditSwirlFreq</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UnitValueEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/swirlFreq</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>How fast the swirl spins.</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407df000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000404e0000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>00000000403e0000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>SwirlFreq</data></node>
         <node f="42" dt="2"><name>valueType</name><data>rate</data></node>
         <node f="42" dt="1"><name>isHotlink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>rateNumerator</name><data>rad</data>
          <node f="40"><name></name></node>
          <node f="4000000042" dt="2"><name>single</name><data>radian</data></node>
          <node f="4000000042" dt="2"><name>plural</name><data>radians</data></node>
         </node>
        </node>
       </data></node>
       <node f="42" dt="4"><name>SizeStart</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407fa000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Size Start</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditSizeStart</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>00000000407f7000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/sizeStart</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Particle diameter at birth.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Prewarm</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>length</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../SizeStart</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>SizeStart</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>SizeEnd</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040809000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Size End</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditSizeEnd</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040807800</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/UniversalEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;variables/sizeEnd</data></node>
        <node f="42" dt="2"><name>tooltip</name><data>Particle diameter at the end of its life.</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>codedescription</name><data>Prewarm</data></node>
         <node f="42" dt="2"><name>picklist</name><data>VIEW:/custompicklists/sourcetimepicklist</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name></name><data>VIEW:/picklists/timepicklist</data></node>
         </node>
         <node f="42" dt="1"><name>isHotLink</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>unitType</name><data>length</data></node>
         <node f="42" dt="1"><name>hasDragTarget</name><data>000000003ff00000</data></node>
         <node f="42" dt="1"><name>valType</name><data>000000003ff00000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>number</name></node>
         </node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../SizeEnd</data></node>
         <node f="42" dt="1"><name>isQuickProp</name><data>000000003ff00000</data></node>
         <node f="42" dt="2"><name>propName</name><data>SizeEnd</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>Seed</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040815000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040584000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402e0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Seed</data></node>
       </data></node>
       <node f="42" dt="4"><name>EditSeed</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/QuickProps/Number</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000405e0000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040813800</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040618000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040080000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>propName</name><data>Seed</data></node>
         <node f="42" dt="2"><name>inheritanceIndicator</name><data>~/../Seed</data></node>
        </node>
        <node f="42" dt="2"><name>tooltip</name><data>Random seed; change it to vary the random pattern.</data></node>
        <node f="42"><name>style</name>
         <node f="40"><name></name></node>
         <node f="42"><name>ES_NUMBER</name></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>File</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>000000004059c000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040821000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040488000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>00000000402c0000</data></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>File Path</data></node>
       </data>
        <node f="40"><name></name></node></node>
       <node f="42" dt="4"><name>FileEdit</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040594000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040568000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004081f800</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040743000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="2"><name>coldlink</name><data>../..&gt;objectfocus+&gt;visual/imageobject</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="4000000042" dt="2"><name>tooltip</name><data>A 2D image file used for texturing the plane and other 3D shapes.</data></node>
        <node f="42" dt="1"><name>alignrightmargin</name><data>0000000040468000</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>applyTexture</name><data>Object focus = node("..&gt;objectfocus+", c);

int undoId = beginaggregatedundo(c, "Change Texture");
createundorecord(c, c, UNDO_CUSTOM);
	focus.setProperty("Texture", getviewtext(c));	
	function_s(c.up, "setPropertyOnAllSelected", "Texture", getviewtext(c), c, focus);
createundorecord(c, c, UNDO_CUSTOM);
endaggregatedundo(c, undoId);

repaintall();
</data></node>
         <node f="442" dt="2"><name>OnKillFocus</name><data>function_s(c, "applyTexture");
</data></node>
        </node>
        <node f="42"><name>style</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>FS_INHERITANCE_INDICATOR</name><data>~</data>
          <node f="40"><name></name></node>
          <node f="42" dt="2"><name>property</name><data>Texture</data></node>
          <node f="42" dt="2"><name>focus</name><data>~/..&gt;objectfocus+</data></node>
          <node f="42" dt="2"><name>additional</name><data>~/../File</data></node>
         </node>
        </node>
       </data></node>
       <node f="42" dt="4"><name>Browse Texture</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040789000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004081f800</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>menucode</name><data>setviewtext(node("../FileEdit", ownerobject(c)), "%path%"); 
function_s(node("../FileEdit", ownerobject(c)), "applyTexture");
</data></node>
         <node f="42" dt="2"><name>browsecode</name><data>function_s(ownerobject(c), "browse");</data></node>
         <node f="4000000042" dt="2"><name>browseText</name><data>Browse...</data></node>
        </node>
        <node f="42" dt="1"><name>menupopup</name><data>000000003ff00000</data>
         <node f="40"><name></name></node></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>OnPress</name><data>treenode menu = menupopup(c);

clearcontents(menu);

nodeinsertinto(menu);
nodeadddata(last(menu), DATATYPE_STRING);
setname(last(menu), getvarstr(c, "browseText"));
sets(last(menu), getvarstr(c, "browsecode"));

nodeinsertinto(menu);
setname(last(menu), "-");

string menucode = getvarstr(c, "menucode");

//Grab all images from the media folder
forobjectlayerunder(node("/project/media/images",maintree())) {
	if (get(a) != 0) {
		nodeinsertinto(menu);
		treenode newshape = last(menu);
		nodeadddata(newshape, DATATYPE_STRING);
		sets(newshape, stringreplace(menucode, "%path%", stringreplace(getname(a), "\\", "\\\\")));
			
		string token = getname(a);
		string name = stringtoken(token,"\\");
		
		while (stringlen(name)&gt;0) {
			string nextname = stringtoken(NULL,"\\");
			if (stringlen(nextname) == 0){
				setname(newshape, name);
				break;
			}
			name = stringtoken(NULL,"\\");
			if (stringlen(name) == 0){
				setname(newshape, nextname);
				break;
			}
		}
	}
}
</data>
          <node f="40"><name></name></node></node>
         <node f="442" dt="2"><name>browse</name><data>treenode openpathnode = node("VIEW:/environment/mediapath");
string filepath;
string directory = applicationcommand("getmediadirectory");

filepath = filebrowse("*.bmp;*.jpg;*.png;*.gif;*.ico","2D images",directory);
if (stringlen(filepath)&gt;4) {
	int cdirlen = stringlen(cdir());
	sets(openpathnode, filepath);
	filepath = truncatemediapath(filepath);

	setviewtext(node("../FileEdit", c),filepath); 
	function_s(node("../FileEdit", c), "applyTexture");
	
	setitem(node("..&gt;objectfocus+",c));
	if (gettextureindex(gets(imageobject(item)))==0)
		autoloadimages();
	set(imageindexobject(item), gettextureindex(gets(imageobject(item))));

	repaintall();
}
</data></node>
        </node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="42" dt="2"><name>tooltip</name><data></data></node>
        <node f="42" dt="2"><name>bitmap</name><data>buttons\down_arrow_small.bmp</data></node>
        <node f="42" dt="1"><name>beveltype</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>alignrightposition</name><data>0000000040468000</data></node>
       </data></node>
       <node f="42" dt="4"><name>3DTextureSampler</name><data>
        <node f="40"><name>object</name></node>
        <node f="42" dt="1"><name>viewwindowtype</name><data>0000000040590000</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/guiclasses/SamplerButton</data></node>
        <node f="42" dt="2"><name>viewfocus</name><data>../../FileEdit</data></node>
        <node f="42" dt="2"><name>objectfocus</name><data>../..&gt;objectfocus+&gt;visual/imageobject</data></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000040590000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>000000004081f800</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>0000000040350000</data></node>
        <node f="42" dt="1"><name>alignrightposition</name><data>0000000040380000</data></node>
        <node f="42" dt="2"><name>undohistory</name><data>../..</data></node>
        <node f="4000000042" dt="2"><name>tooltip</name><data>Click this button then "sample" something in FlexSim like
an object in the model or the library to define the conveyor's Texture.</data></node>
        <node f="42"><name>variables</name>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>valType</name><data>0000000040500000</data>
          <node f="40"><name></name></node>
          <node f="42"><name>picture</name></node>
         </node>
        </node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>onSample</name><data>function_s(node("../FileEdit", c), "applyTexture");</data></node>
        </node>
       </data>
        <node f="40"><name></name></node></node>
      </node>
     </node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_Modules</name><data>MAIN:/project/exec/globals/helpmanual/TableOfContents/Modules</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>FlexScript API Reference</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42" dt="4"><name>Particles</name><data>
      <node f="40"><name></name></node>
      <node f="4000000042" dt="2"><name>windowtitle</name><data>Particles</data></node>
     </data>
      <node f="40"><name> </name></node>
      <node f="42" dt="4"><name>What's New</name><data>
       <node f="40"><name></name></node>
       <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/manual/WhatsNew.html</data></node>
       <node f="42" dt="2"><name>uniqueid</name><data>Particles::WhatsNew</data></node>
      </data></node>
      <node f="42" dt="4"><name>Property Panels</name><data>
       <node f="40"><name></name></node>
      </data>
       <node f="40"><name></name></node>
       <node f="42" dt="4"><name>Particle System Properties</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.SystemPanel.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::ParticleSystemPanel</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particle Emitter Properties</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.EmitterPanel.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::Emitter</data></node>
       </data></node>
      </node>
      <node f="42" dt="4"><name>FlexScript API Reference</name><data>
       <node f="40"><name></name></node>
      </data>
       <node f="40"><name></name></node>
       <node f="42" dt="4"><name>Particles</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Particles</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.System</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.System.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::System</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.Emitter</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.Emitter.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Emitter</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.Color</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.Color.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Color</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.Vec3</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.Vec3.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Vec3</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.Shape</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.Shape.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Shape</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.Direction</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.Direction.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Direction</data></node>
       </data></node>
       <node f="42" dt="4"><name>Particles.Style</name><data>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>viewfocus</name><data>modules/Particles/FlexScriptAPIReference/Particles/Particles.Style.html</data></node>
        <node f="42" dt="2"><name>uniqueid</name><data>Particles::API::Style</data></node>
       </data></node>
      </node>
     </node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_tools</name><data>VIEW:/standardviews/modelingutilities/Toolbox&gt;variables/tools</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>ParticleSystem</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>Workspaces</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42" dt="4"><name>ParticleSystem</name><data>
      <node f="40"><name></name></node>
      <node f="42" dt="2"><name>objectfocus</name><data>MODEL:/ParticleSystem</data></node>
      <node f="42" dt="2"><name>bitmap</name><data>modules\Particles\bitmaps\ParticleSystem.png</data></node>
      <node f="42"><name>variables</name>
       <node f="40"><name></name></node>
       <node f="42" dt="2"><name>menuBitmap</name><data>modules\RouteGraph\bitmaps\routegraph.png</data></node>
       <node f="42" dt="2"><name>toolType</name><data>Singleton</data></node>
      </node>
      <node f="42"><name>eventfunctions</name>
       <node f="40"><name></name></node>
       <node f="442" dt="2"><name>onDoubleClick</name><data>createview("VIEW:/modules/Particles/Pages/ParticleSystemProperties", "MODEL:/ParticleSystem", "MODEL:/ParticleSystem");</data></node>
       <node f="442" dt="2"><name>onDelete</name><data>return 1;</data></node>
      </node>
      <node f="4000000042" dt="2"><name>windowtitle</name><data>Particle System</data></node>
     </data></node>
    </node>
   </node>
  </node>
 </node>
 <node f="42" dt="2"><name>release</name><data>26.0</data></node>
 <node f="42" dt="2"><name>revision</name><data>.0</data></node>
 <node f="42" dt="2"><name>flexsim release</name><data>26.0</data></node>
</node></flexsim-tree>
