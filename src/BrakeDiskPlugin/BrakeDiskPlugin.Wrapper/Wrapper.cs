namespace BrakeDiskPlugin.Wrapper
{
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Provides methods to connect to KOMPAS-3D, create and manipulate 3D documents.
    /// </summary>
    public class Wrapper
    {
        /// <summary>
        /// Represents the Pro/Engineer (KOMPAS) application ID.
        /// </summary>
        private const string KompasID = "KOMPAS.Application.5";

        /// <summary>
        /// The KOMPAS 3D application object.
        /// </summary>
        private KompasObject? _kompasObject;

        /// <summary>
        /// The 3D document within the KOMPAS environment.
        /// </summary>
        private ksDocument3D? _document3D;

        /// <summary>
        /// The current part within the 3D document.
        /// </summary>
        private ksPart? _part;

        /// <summary>
        /// The sketch entity within the current part.
        /// </summary>
        private ksEntity? _sketch;

        /// <summary>
        /// The definition of the current sketch.
        /// </summary>
        private ksSketchDefinition? _sketchDefinition;

        /// <summary>
        /// Attempts to establish a connection with KOMPAS-3D.
        /// </summary>
        public void ConnectToCad()
        {
            try
            {
                _kompasObject = CustomMarshal.GetActiveObject(KompasID) as KompasObject;
            }
            catch
            {
                var compassType = Type.GetTypeFromProgID(KompasID);
                if (compassType != null)
                {
                    _kompasObject = Activator.CreateInstance(compassType) as KompasObject;
                }

                if (_kompasObject == null)
                {
                    throw new Exception("Unable to connect to KOMPAS-3D");
                }

                _kompasObject.Visible = true;
            }
        }

        /// <summary>
        /// Creates a new 3D document within KOMPAS-3D.
        /// </summary>
        public void CreateDocument3D()
        {
            _document3D = (ksDocument3D?)_kompasObject.Document3D();
            _document3D?.Create();
            _part = (ksPart?)_document3D.GetPart((int)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Creates a sketch in the current 3D document.
        /// </summary>
        /// <returns>The definition of the created sketch.</returns>
        public ksSketchDefinition CreateSketch()
        {
            var plane = (ksEntity)_part.GetDefaultEntity((int)Obj3dType.o3d_planeXOZ);
            _sketch = (ksEntity?)_part.NewEntity((int)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition?)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(plane);
            _sketch.Create();
            return _sketchDefinition;
        }

        /// <summary>
        /// Creates a boss extrusion with the specified depth and optional side parameter.
        /// </summary>
        /// <param name="depth">The depth of the boss extrusion.</param>
        /// <param name="side">Optional parameter to determine the side of the extrusion (default is true).</param>
        public void MakeExtrusion(double depth, bool side = true)
        {
            PerformExtrusion(
                (ksEntity?)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion),
                (short)Obj3dType.o3d_bossExtrusion,
                depth,
                side);
        }

        /// <summary>
        /// Creates a cut extrusion with the specified depth and optional side parameter.
        /// </summary>
        /// <param name="depth">The depth of the cut extrusion.</param>
        /// <param name="side">Optional parameter to determine the side of the extrusion (default is true).</param>
        public void CutMakeExtrusion(double depth, bool side = true)
        {
            PerformExtrusion(
                (ksEntity?)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion),
                (short)Obj3dType.o3d_cutExtrusion,
                depth,
                side);
        }

        /// <summary>
        /// Performs an extrusion operation based on the specified extrusion entity, type, depth, and side
        /// parameters.
        /// </summary>
        /// <param name="extrusionEntity">The entity representing the extrusion in the CAD environment.</param>
        /// <param name="extrusionType">The type of extrusion (boss or cut).</param>
        /// <param name="depth">The depth of the extrusion.</param>
        /// <param name="side">Determines the side of the extrusion.</param>
        // TODO: extrusionType не используется
        private void PerformExtrusion(
            ksEntity? extrusionEntity,
            short extrusionType,
            double depth,
            bool side)
        {
            var extrusion = extrusionEntity?.GetDefinition();

            if (extrusion is ksBossExtrusionDefinition bossExtrusionDefinition)
            {
                bossExtrusionDefinition.SetSideParam(side, (short)End_Type.etBlind, depth);
                bossExtrusionDefinition.directionType = side
                    ? (short)Direction_Type.dtNormal
                    : (short)Direction_Type.dtReverse;
                bossExtrusionDefinition.SetSketch(_sketch);
            }
            else if (extrusion is ksCutExtrusionDefinition cutExtrusionDefinition)
            {
                cutExtrusionDefinition.SetSideParam(side, (short)End_Type.etBlind, depth);
                cutExtrusionDefinition.directionType = side
                    ? (short)Direction_Type.dtNormal
                    : (short)Direction_Type.dtReverse;
                cutExtrusionDefinition.SetSketch(_sketch);
            }

            extrusionEntity?.Create();
        }
    }
}